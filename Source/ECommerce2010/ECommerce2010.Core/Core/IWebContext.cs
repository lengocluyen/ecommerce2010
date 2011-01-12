using System;
using System.Collections.Generic;
using System.Web;

namespace ECommerce2010.Core
{
    public interface IWebContext
    {
        void ClearSession();
        bool ContainsInSession(string key);
        void RemoveFromSession(string key);
        string RootUrl { get; }
        bool LoggedIn { get; set; }
        string Username { get; set;  }
        User CurrentUser { get; set; }
        string CaptchaImageText { get; set; }
        DateTime TimeUserLogin { get; set; }
        Role RoleCurrentUser { get; set; }
      
    }
}