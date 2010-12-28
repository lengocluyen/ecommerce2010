using System;
using System.Collections.Generic;

using System.Web.Mvc;

namespace Libs
{
    public static class HtmlHelpers
    {
        /// <summary>
        /// This is a simple HTML Helper which truncates a string to a given length
        /// </summary>
        /// <param name="input">Input string to truncate</param>
        /// <param name="length">Max length of the string</param>
        /// <returns></returns>
        public static string Truncate(string input, int length)
        {
            if (input.Length <= length)
            {
                return input;
            }
            else
            {
                return input.Substring(0, length) + "...";
            }
        }
    }
}
