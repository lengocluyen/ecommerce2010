using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ECommerce2010.Core
{
    public class QueryHelper
    {
        //get query string 
        public static string GetQueryString(HttpRequest request, string query)
        {
            try
            {
                return request.QueryString[query].ToString();
            }
            catch
            {
                return "";
            }
        }

    }
}
