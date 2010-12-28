using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Libs
{
    public class LibFile
    {
        public static void WriteFile(string name, string content)
        {
            try
            {
                FileStream fs = new FileStream(name, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
                TextWriter writer = new StreamWriter(fs);
                try
                {
                    writer.Write(content);
                }
                catch { }
                finally
                {
                    writer.Close();
                }
            }
            catch { }
        }

        public static void AppendFile(string name, string content)
        {
            try
            {
                StreamWriter sw = File.AppendText(name);
                try
                {
                    sw.Write(content);
                }
                catch { }
                finally
                {
                    sw.Close();
                }
            }
            catch { }
        }

        public static string ReadFile(string name)
        {
            string result = "";
            try
            {
                TextReader reader = new StreamReader(name);
                try
                {
                    result = reader.ReadToEnd();
                }
                catch { }
                finally
                {
                    reader.Close();
                }
            }

            catch { }

            return result;
        }


        public static void DeleteDirectory(string path)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                dir.Delete(true);
            }
            catch { }
        }

        public static void DeleteFile(string path)
        {
            try
            {
                FileInfo file = new FileInfo(path);
                file.Delete();
            }
            catch { }
        }

        public static void RenameFile(string oldFile, string newFile)
        {
            try
            {
                FileInfo file = new FileInfo(oldFile);
                if (file.Exists)
                {
                    File.Copy(oldFile, newFile, true);
                    file.Delete();
                }
            }
            catch { }
        }
    }
}