using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Configuration;

namespace Libs
{
    public class LibUlti
    {
        /// <summary>
        /// Remove vietnam sign
        /// </summary>
        /// <param name="str">the input string contains vietnam sign</param>
        /// <returns>the input without vietnam sign</returns>
        public static string RemoveVietnameseSigns(string str)
        {
            str = str.Trim();
            string[] arrConvertChars = new string[] { "aAeEoOuUiIdDyY_", "áàạảãâấầậẩẫăắằặẳẵ", "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ", "éèẹẻẽêếềệểễ", "ÉÈẸẺẼÊẾỀỆỂỄ", "óòọỏõôốồộổỗơớờợởỡ",
                "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ", "úùụủũưứừựửữ", "ÚÙỤỦŨƯỨỪỰỬỮ", "íìịỉĩ", "ÍÌỊỈĨ", "đ", "Đ", "ýỳỵỷỹ", "ÝỲỴỶỸ", "!@%^*()+=<>?/,.:;' \"&#[]~$\\" };

            for (int i = 1; i < arrConvertChars.Length; i++)
            {
                for (int j = 0; j < arrConvertChars[i].Length; j++)
                    str = str.Replace(arrConvertChars[i][j], arrConvertChars[0][i - 1]);
            }

            return str;
        }

        /// <summary>
        /// Download File From Internet
        /// </summary>
        /// <param name="fileAddress">URL : http://nus.vn/logo-nus.jpg </param>
        /// <param name="savePath">Physical path contain this file : ~\Download\logo-nus.jpg</param>
        /// <returns></returns>
        public static bool DownLoadFileFromInternet(string fileAddress, string savePath)
        {
            try
            {
                System.Net.WebClient webClient = new System.Net.WebClient();
                webClient.DownloadFile(new Uri(fileAddress, UriKind.Absolute), savePath);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Delete file
        /// </summary>
        /// <param name="path">spath of file , ex : ~/Upload/Image/avatar.jpg</param>
        /// <returns>true | false: Success or Error</returns>
        public static bool DeleteFile(string path)
        {
            bool bResult = false;
            path = HttpContext.Current.Server.MapPath(path);

            try
            {
                System.IO.File.Delete(path);
                bResult = true;
            }
            catch
            {
                bResult = false;
            }
            return bResult;
        }

        /// <summary>
        /// Get Full URL path of image , eg:"http://abc.com/Upload/Avatar/myAvatar.jpg"
        /// </summary>
        /// <param name="ImageFolder">ex: /Upload/Avatar/</param>
        /// <param name="imgURL">ex: myAvatar.jpg</param>
        /// <returns>full path of image , ex: 'http://abc.com/Upload/Avatar/myAvatar.jpg', unless return to default image path in web.config with key="NoImagePath"</returns>
        public static string GetImageURL(string ImageFolder, object imgURL)
        {
            if (imgURL != null)
                if (imgURL.ToString() == "System.Object")
                    imgURL = null;

            string urlResult = null;
            string currentURL = LibConvert.ForceString(imgURL);

            if (currentURL == string.Empty)
            {
                string configImage = ConfigurationManager.AppSettings.Get("NoImagePath");
                urlResult = GetServerURL() + configImage;
            }
            else
                urlResult = GetServerURL() + ImageFolder + LibConvert.ForceString(imgURL);

            return urlResult;
        }

        /// <summary>
        /// Get Server URL ex: http://abc.com
        /// </summary>
        /// <returns>server url ex: 'http://abc.com'</returns>
        public static string GetServerURL()
        {
            StringBuilder result = new StringBuilder();
            if (System.Web.HttpContext.Current.Request.ServerVariables["SERVER_PORT_SECURE"] == "0")
                result.Append("http://");
            else
                result.Append("https://");
            result.Append(System.Web.HttpContext.Current.Request.ServerVariables["HTTP_HOST"]);
            result.Append(System.Web.HttpContext.Current.Request.ApplicationPath);

            string resultText = result.ToString();
            if (resultText.IndexOf("/", resultText.Length - 1) != -1)
                resultText = resultText.Remove(resultText.Length - 1, 1);
            return resultText;
        }

        /// <summary>
        /// Read file on server
        /// </summary>
        /// <param name="path">Relative Path of file on server ex: ~\MailTemplate\Test.htm</param>
        /// <returns>Return file's content</returns>
        public static string ReadFile(string path)
        {
            path = HttpContext.Current.Server.MapPath(path);
            //path = path.Replace("NUSAdmin\\", "");
            System.IO.FileStream stream = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
            System.IO.StreamReader reader = new System.IO.StreamReader(stream);

            string file = "";
            try
            {
                file = reader.ReadToEnd();
            }
            catch
            {
            }
            reader.Close();
            stream.Close();
            return file;
        }
    }
}
