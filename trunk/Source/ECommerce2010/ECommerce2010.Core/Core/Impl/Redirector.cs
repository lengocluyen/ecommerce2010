using System;
using System.Web;

namespace ECommerce2010.Core
{
    public class Redirector : IRedirector
    {
      
        public void GoToHomePage()
        {
            Redirect("~/Default.aspx");
        }
        public void GoToErrorPage()
        {
            Redirect("~/Error.aspx");
        }
        public void GotoLoginPage()
        {
            Redirect("~/CMS/Login.aspx");
        }
        public void GotoAdminPage()
        {
            Redirect("~/CMS/Default.aspx");
        }
        private void Redirect(string path)
        {
            HttpContext.Current.Response.Redirect(path);
        }
     
    }
}
