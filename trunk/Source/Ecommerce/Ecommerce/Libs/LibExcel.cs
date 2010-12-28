using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Threading;
using System.IO;
using System.Data.OleDb;
using System.Data;

namespace Libs
{
    public class LibExcel
    {
        string _connectionString = "";
        string _sheetName = "";
        string _fileForStoreProgress = "";
        FileInfo _excelFile = null;

        public delegate void DelegateReadOneRow(DbDataReader dr, bool isLastRow);
        public DelegateReadOneRow dlgReadOneRow;


        #region PUBLIC FIELDs

        public string FileForStoreProgress
        {
            get { return _fileForStoreProgress; }
            set { _fileForStoreProgress = value; }
        }

        public FileInfo ExcelFile
        {
            get { return _excelFile; }
            set { _excelFile = value; }
        }

        public string SheetName
        {
            get { return _sheetName; }
            set { _sheetName = value; }
        }

        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        #endregion

        /// <summary>
        /// Init excel files with neccesary variables
        /// </summary>
        /// <param name="fileLocation">Location of excel file</param>
        /// <param name="sheetName">Sheet name</param>
        /// <param name="fileForStoreProgress">Location of file to save progress</param>
        public LibExcel(string fileLocation, string sheetName, string fileForStoreProgress)
        {
            this.ExcelFile = new FileInfo(fileLocation);
            if (!_excelFile.Exists)
                throw new Exception("File không tồn tại!");

            this.SheetName = sheetName;
            this.FileForStoreProgress = fileForStoreProgress;

            this.ConnectionString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=YES;\"", this.ExcelFile.FullName);

            if (this.SheetName == "")
                this.SheetName = GetExcelSheetNames()[0];
        }

        public void Read()
        {
            Thread thread = new Thread(new ThreadStart(BeginRead));
            thread.IsBackground = true;
            thread.Start();
        }

        void BeginRead()
        {
            int totalRows = CountRows();

            DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = this.ConnectionString;

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM [" + this.SheetName + "]";

                    connection.Open();

                    int count = 0;
                    using (DbDataReader dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (count + 1 == totalRows)
                                dlgReadOneRow(dr, true);
                            else
                                dlgReadOneRow(dr, false);

                            // Progress
                            count++;
                            double percent = Math.Round((double)count / (double)totalRows * 100, 0);
                            LibFile.WriteFile(this.FileForStoreProgress, percent.ToString());
                        }
                    }
                }
            }

            //FileHandle.DeleteFile(this.FileForStoreProgress);
            this.ExcelFile.Delete();
        }

        private String[] GetExcelSheetNames()
        {
            OleDbConnection objConn = null;
            DataTable dt = null;

            try
            {
                objConn = new OleDbConnection(this.ConnectionString);
                objConn.Open();

                // Get the data table containg the schema guid.
                dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                if (dt == null)
                {
                    return null;
                }

                String[] excelSheets = new String[dt.Rows.Count];
                int i = 0;

                // Add the sheet name to the string array.

                foreach (DataRow row in dt.Rows)
                {
                    excelSheets[i] = row["TABLE_NAME"].ToString();
                    i++;
                }

                return excelSheets;
            }
            catch
            {
                return null;
            }
            finally
            {
                // Clean up.

                if (objConn != null)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
                if (dt != null)
                {
                    dt.Dispose();
                }
            }
        }

        private int CountRows()
        {
            int result = 0;

            DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = this.ConnectionString;

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT count(*) FROM [" + this.SheetName + "]";

                    connection.Open();

                    using (DbDataReader dr = command.ExecuteReader())
                    {
                        dr.Read();
                        result = LibConvert.ConvertToInt(dr[0], 0); ;
                    }
                }
            }

            return result;
        }
    }
}