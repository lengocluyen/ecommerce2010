using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Web;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace ECommerce2010.Core
{
    public enum ListRole
    {
        PUBLIC = 1,
        ADMINISTRATOR,
        MODERATOR,
        REGISTERED

    }
    public enum TypeAttribute
    {
        Source=1,
        Audio,
        Appendix,
        Presentation

    }
    public enum Languages
    {
        English,
        Poland
    }
    public class Utils
    {
        public const string flychips = "|FLYCHIPS|";
        public static string GetStringInString(string source, string a,int i)
        {
            string[] sr = {a};
            string[] s = source.Split(sr, StringSplitOptions.None);
            return s[i];
        }
        public static string GetAbsolutelyLink(string linkImage)
        {
            string link =".."+linkImage.Replace(@"\","/");
            return link;
        }
        public static string GetNotMap(string s, string o)
        {
            string a = s.ToLower();

            a =  "~/"+a.Substring(a.IndexOf(o.ToLower()), a.Length - a.IndexOf(o.ToLower()));
            a = a.Replace(@"\", "/");
            if (a.LastIndexOf("/") != a.Length - 1) a = a + "/";
            return a;
        }
        //public static string GetObjectLink(string s, string o)
        //{
        //    string a = s.ToLower();
        //    a = a.Substring(a.LastIndexOf(o.ToLower()), a.Length - (a.LastIndexOf(o.ToLower())));
        //}
        public static void ResponseFileToUser(string file, HttpContext http)
        {

            //To Get the physical Path of the file(me2.doc)
            string filepath = file;

            // Create New instance of FileInfo class to get the properties of the file being downloaded
            FileInfo myfile = new FileInfo(filepath);

            // Checking if file exists
            if (myfile.Exists)
            {
                // Clear the content of the response
                http.Response.ClearContent();

                // Add the file name and attachment, which will force the open/cancel/save dialog box to show, to the header
                http.Response.AddHeader("Content-Disposition", "attachment; filename=" + myfile.Name);

                // Add the file size into the response header
                http.Response.AddHeader("Content-Length", myfile.Length.ToString());

                // Set the ContentType
                http.Response.ContentType = ReturnExtension(myfile.Extension.ToLower());

                // Write the file into the response (TransmitFile is for ASP.NET 2.0. In ASP.NET 1.1 you have to use WriteFile instead)
                http.Response.TransmitFile(myfile.FullName);

                // End the response
                http.Response.End();
            }
        }

        public static string ReturnExtension(string fileExtension)
        {
            switch (fileExtension)
            {
                case ".htm":
                case ".html":
                case ".log":
                    return "text/HTML";
                case ".txt":
                    return "text/plain";
                case ".doc":
                    return "application/ms-word";
                case ".tiff":
                case ".tif":
                    return "image/tiff";
                case ".asf":
                    return "video/x-ms-asf";
                case ".avi":
                    return "video/avi";
                case ".zip":
                    return "application/zip";
                case ".xls":
                case ".csv":
                    return "application/vnd.ms-excel";
                case ".gif":
                    return "image/gif";
                case ".jpg":
                case "jpeg":
                    return "image/jpeg";
                case ".bmp":
                    return "image/bmp";
                case ".wav":
                    return "audio/wav";
                case ".mp3":
                    return "audio/mpeg3";
                case ".mpg":
                case "mpeg":
                    return "video/mpeg";
                case ".rtf":
                    return "application/rtf";
                case ".asp":
                    return "text/asp";
                case ".pdf":
                    return "application/pdf";
                case ".fdf":
                    return "application/vnd.fdf";
                case ".ppt":
                    return "application/mspowerpoint";
                case ".dwg":
                    return "image/vnd.dwg";
                case ".msg":
                    return "application/msoutlook";
                case ".xml":
                case ".sdxl":
                    return "application/xml";
                case ".xdp":
                    return "application/vnd.adobe.xdp+xml";
                default:
                    return "application/octet-stream";
            }
        }
        public static string HandleURL(string url, string query)
        {
            if (url.Contains(query + "="))
                url = url.Remove(url.IndexOf(query + "=") - 1);
            if (url.Contains("aspx?"))
                url = url + "&";
            else
                url = url + "?";

            return url;
        }
        public static string ChangeDateFormat(string date)
        {
            string[] arr = date.Split('/');
            return arr[1] + "/" + arr[0] + "/" + arr[2];
        }
        public static string Encode(string str)
        {
            Byte[] original;
            Byte[] encode;
            MD5 md5 = new MD5CryptoServiceProvider();

            original = ASCIIEncoding.Default.GetBytes(str);
            encode = md5.ComputeHash(original);

            return BitConverter.ToString(encode);
        }

        public static int GenerateRandomNumber()
        {
            Random rand = new Random();
            return rand.Next();
        }

        public static string GenerateRandomPassword()
        {
            return System.Web.Security.Membership.GeneratePassword(7, 3);
        }

        public static string GenerateRandomString(int n)
        {
            return System.Web.Security.Membership.GeneratePassword(n, 0);
        }

        public static string AdjustTinyMCEContent(string str) // Bo ki tu <p> o dau va </p> o cuoi
        {
            str = str.Substring(3, str.Length - 3);
            str = str.Remove(str.IndexOf("</p>"), 4);
            return str;
        }

        public static string SqlInjectionProtect(string str)
        {
            str = str.Replace("'", "!-|-!.daunhaydon.!-|-!");
            str = str.Replace("%", "!-|-!.dauphantram.!-|-!");
            str = str.Replace("_", "!-|-!.daugachngang.!-|-!");
            return str;
        }

        public static string SqlInjectionDeprotect(string str)
        {
            str = str.Replace("!-|-!.daunhaydon.!-|-!", "'");
            str = str.Replace("!-|-!.dauphantram.!-|-!", "%");
            str = str.Replace("!-|-!.daugachngang.!-|-!", "_");
            return str;
        }

        public static void SendMail(string sToEmail, string sSubject, string sMessage)
        {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = ConfigurationManager.AppSettings["SmtpHost"].ToString();
            smtpClient.Port = int.Parse(ConfigurationManager.AppSettings["SmtpPort"].ToString());
            smtpClient.EnableSsl = bool.Parse(ConfigurationManager.AppSettings["isSSL"].ToString());
            smtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["Username"].ToString(), ConfigurationManager.AppSettings["Password"].ToString());

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(ConfigurationManager.AppSettings["defaultSender"].ToString());
            mail.Sender = new MailAddress(ConfigurationManager.AppSettings["defaultSender"].ToString());
            mail.To.Add(new MailAddress(sToEmail));
            mail.Subject = sSubject;
            mail.Body = sMessage;
            mail.IsBodyHtml = true;

            smtpClient.Send(mail);
        }

        public static string StringToUpper(string str)
        {
            string[] arr = str.ToLower().Split(' ');
            str = "";
            foreach (string s in arr)
                str += s[0].ToString().ToUpper() + s.Remove(0, 1) + " ";

            return str;
        }

        public static string StringInsertLeftRight(string strMain, string key, string strLeft, string strRight)
        {
            int count = 0;
            string result = "";
            int start = 0;
            for (int i = 0; i < strMain.Length; i++)
            {
                if (strMain[i].ToString().ToLower() == key[count].ToString().ToLower())
                {
                    count++;
                    if (count == key.Length) // OK
                    {
                        result += strMain.Substring(start, i + 1 - key.Length - start) + strLeft + strMain.Substring(i + 1 - key.Length, key.Length) + strRight;
                        start = i + 1;
                        count = 0;
                    }

                }
                else
                    count = 0;
            }
            result += strMain.Substring(start, strMain.Length - start);
            return result;
        }
        public static int GetID(string input)
        {
            int kq = 0;
            if (input != "")
            {
                int kt = input.IndexOf(")");
                string t = input.Substring(1, kt - 1);
                kq = int.Parse(t);
            }
            return kq;
        }
        public static string GetPageName(string url)
        {
            int start = url.LastIndexOf("/") + 1;
            int len = url.IndexOf(".aspx", start) - start;
            return url.Substring(start, len);
        }
    }
}
