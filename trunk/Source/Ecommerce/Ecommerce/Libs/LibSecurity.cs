using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Text;

namespace Libs
{
    public class LibSecurity
    {
        //== SQL Injection
        public static string KillSQLInjection(string input)
        {
            if (CheckXSS(new string[] { input }))
                return "";
            if (input != null)
            {
                string[] sqlinjection = new string[] { "select", "drop", ";", "--", "insert", "delete", "xp_", "update", "'", @"""", "or", "=" };
                string output = input;
                foreach (string str in sqlinjection)
                {
                    output = output.Replace(str, "");
                }
                return output;
            }
            return "";
        }

        public static bool CheckXSS(string[] input)
        {
            if (input.Length > 0)
            {
                foreach (string str in input)
                {
                    if (str.IndexOf("<") >= 0 || str.IndexOf("%3C") >= 0 || str.IndexOf("&lt;") >= 0 || str.IndexOf("\x3c") >= 0)
                        return true;
                }
            }
            return false;
        }
        //==End SQL Injection

        /// <summary>
        /// Encode password with MD5 format
        /// </summary>
        /// <param name="strPassword">the password need to encode</param>
        /// <returns>password encoded</returns>
        public static string EncodePassword(string strPassword)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(strPassword + "LibSecurity", "MD5");
        }

        /*--------------Password Generator---------*/
        private static char[] characterArray = "abcdefzABCDEFGHIJXYZ0123456789".ToCharArray();

        private static Random randNum = new Random();

        static char GetRandomCharacter()
        {
            return characterArray[(int)((characterArray.GetUpperBound(0) + 1) * randNum.NextDouble())];
        }

        /// <summary>
        /// Generate random string
        /// </summary>
        /// <param name="len">lenght of string need to generate</param>
        /// <returns>random string with lenght is 'len'</returns>
        public static string GenerateRandomString(int len)
        {
            StringBuilder sb = new StringBuilder();
            sb.Capacity = len;
            for (int count = 0; count <= sb.Capacity - 1; count++)
            {
                sb.Append(GetRandomCharacter());
            }
            if ((sb != null))
            {
                return sb.ToString();
            }
            return "123ABC";
        }

        /// <summary>
        /// Random File Name
        /// </summary>
        /// <returns></returns>
        public static string RandomFileName()
        {
            string fileName = (DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString());
            Random rand = new Random((int)DateTime.Now.Ticks);
            int a = rand.Next();

            fileName += a.ToString();
            return fileName;
        }
    }
}
