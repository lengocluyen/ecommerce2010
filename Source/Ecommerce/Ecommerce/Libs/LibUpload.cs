using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI.WebControls;

namespace Libs
{
    public class LibUpload
    {
        /// <summary>
        ///     Upload file with some format
        /// </summary>
        /// <param name="objectFile"></param>
        /// <param name="pathDirectory">relative path ex: ~/Upload/Avatar/</param>
        /// <param name="errorMess">out put message, ex: succsess or error</param>
        /// <param name="fileName">out put filename when done , ex :2010110634054.jpg</param>
        /// <param name="formatFileName">list of format ex :jpg,jpeg,gif; unless put "" to acccept all type</param>
        /// <returns></returns>
        public static bool UploadFile(HttpPostedFileBase objectFile, string pathDirectory, ref string errorMess, ref string fileName, string formatFileName, int maxSize)
        {
            if (objectFile.FileName != "")
            {
                HttpPostedFileBase postfile = objectFile;
                //Lấy tên phần mở rộng của File được Upload
                string fileExtension = Path.GetExtension(postfile.FileName).ToLower();
                fileExtension = fileExtension.Substring(1, fileExtension.Length - 1);//.jpg->jpg
                /*----------Kiem tra pham mo rong file-----*/
                if (formatFileName != "")
                {
                    if (CheckExtention(formatFileName, fileExtension) == false)//Not exits
                    {
                        errorMess = "Chỉ được chọn file  theo yêu cầu : " + formatFileName;
                        return false;
                    }
                }
                int fileSize = postfile.ContentLength;
                if (fileSize == 0)
                {
                    errorMess = "File không có dung lượng !";
                    return false;
                }

                if (fileSize > maxSize)
                {
                    errorMess = "Chỉ upload những file có dung lượng <= " + (maxSize / 1000).ToString() + "KB";
                    return false;
                }

                fileName = (fileName == string.Empty) ? LibSecurity.RandomFileName() + "." + fileExtension : fileName + LibSecurity.RandomFileName() + "." + fileExtension;
                //Ghi file mới
                try
                {
                    byte[] dataFile = new byte[fileSize];
                    postfile.InputStream.Read(dataFile, 0, fileSize);

                    FileStream newFile = new FileStream(HttpContext.Current.Server.MapPath(pathDirectory + fileName), FileMode.Create);
                    newFile.Write(dataFile, 0, fileSize);
                    newFile.Close();
                    errorMess = "Upload thành công!";
                    return true;
                }
                catch //(Exception e)
                {
                    try
                    {
                        LibUlti.DeleteFile(pathDirectory + fileName);
                        errorMess = "Lỗi trong khi Upload!";// +e.Message;
                        return false;
                    }
                    catch //(Exception ex)
                    {
                        errorMess = "Đường dẫn không đúng ! ";// +ex.Message;
                        return false;
                    }
                }
            }
            else
            {
                errorMess = "Hãy chọn file để upload!";
                return false;
            }
        }

        /// <summary>
        /// Check file extention 
        /// </summary>
        /// <param name="formatFileName">ex : "jpg,jpeg,gif,png"</param>
        /// <param name="ext">ext need to check in listFormat, ex : jpg</param>
        /// <returns></returns>
        public static bool CheckExtention(string formatFileName, string ext)
        {
            List<string> listFormat = ListSpilit(formatFileName, ',');
            foreach (string e in listFormat)
                if (e.ToLower() == ext.ToLower())
                    return true;
            return false;
        }

        public static List<string> ListSpilit(string listFormat, char sperator)
        {
            char[] sperators = new char[] { sperator };
            string str = listFormat;
            string[] lst = str.Split(sperator);
            List<string> l = new List<string>();
            l.AddRange(lst);
            return l;
        }

    }
}