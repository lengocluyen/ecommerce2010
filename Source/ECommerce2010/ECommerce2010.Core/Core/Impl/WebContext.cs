using System;
using System.Collections.Generic;
using System.Web;

namespace ECommerce2010.Core
{
    public class WebContext : IWebContext
    {
        public string RootUrl
        {
            get
            {
                string result;

                string Port = HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
                if (Port == null || Port == "80" || Port == "443")
                    Port = "";
                else
                    Port = ":" + Port;

                string Protocol = HttpContext.Current.Request.ServerVariables["SERVER_PORT_SECURE"];
                if (Protocol == null || Protocol == "0")
                    Protocol = "http://";
                else
                    Protocol = "https://";

                result = Protocol + HttpContext.Current.Request.ServerVariables["SERVER_NAME"] +
                    Port + HttpContext.Current.Request.ApplicationPath;

                return result;
            }
        }  
      
        public string CaptchaImageText
        {
            get
            {
                if(ContainsInSession("CaptchaImageText"))
                {
                    return GetFromSession("CaptchaImageText").ToString();
                }

                return null;
            }

            set
            {
                SetInSession("CaptchaImageText",value);
            }
        }

        public User CurrentUser
        {
            get
            {
                if (ContainsInSession("CurrentUser"))
                {
                    return GetFromSession("CurrentUser") as User;
                }
                return null;
            }
            set
            {
                SetInSession("CurrentUser", value);
            }
        }

        public string Username
        {
            get
            {
                if(ContainsInSession("Username"))
                {
                    return GetFromSession("Username").ToString();
                }

                return "";
            }

            set
            {
                SetInSession("Username",value);
            }
        }
        
        public bool LoggedIn
        {
            get
            {
                if(ContainsInSession("LoggedIn"))
                {
                    if((bool)GetFromSession("LoggedIn"))
                        return true;
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }   
            set
            {
                SetInSession("LoggedIn", value);
            }
        }
        public DateTime TimeUserLogin
        {
            get
            {
                if (ContainsInSession("TimeUserLogin"))
                {
                    return Convert.ToDateTime(GetFromSession("TimeUserLogin"));
                }
                return DateTime.Now;
            }
            set
            {
                SetInSession("TimeUserLogin", value);
            }
        }
        public Role RoleCurrentUser
        {
            get
            {
                if (ContainsInSession("RoleCurrentUser"))
                {
                    return GetFromSession("RoleCurrentUser") as Role;
                }
                return null;
            }
            set
            {
                SetInSession("RoleCurrentUser", value);
            }
        }

        public List<YourCarts> ListCart
        {
            get
            {
                if (ContainsInSession("ListCart"))
                {
                    return GetFromSession("ListCart") as List<YourCarts>;
                }
                return new List<YourCarts>();
            }
            set
            {
                SetInSession("ListCart", value);
            }
        }


        public void ClearSession()
        {
            HttpContext.Current.Session.Clear();
        }

        public bool ContainsInSession(string key)
        {
            if(HttpContext.Current.Session != null && HttpContext.Current.Session[key] != null)
                return true;
            return false;
        }

        public void RemoveFromSession(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }

        private string GetQueryStringValue(string key)
        {
            return HttpContext.Current.Request.QueryString.Get(key);
        }

        private void SetInSession(string key, object value)
        {
            if (HttpContext.Current == null || HttpContext.Current.Session == null)
            {
                return;
            }
            HttpContext.Current.Session[key] = value;
        }

        private object GetFromSession(string key)
        {
            if (HttpContext.Current == null || HttpContext.Current.Session == null)
            {
                return null;
            }
            return HttpContext.Current.Session[key];
        }

        private void UpdateInSession(string key, object value)
        {
            HttpContext.Current.Session[key] = value;
        }
    }
}
