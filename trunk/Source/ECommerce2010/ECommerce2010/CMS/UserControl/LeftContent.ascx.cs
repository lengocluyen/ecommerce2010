using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ECommerce2010.CMS.UserControl
{
    public partial class LeftContent : System.Web.UI.UserControl
    {
        public string ebook = "ebook",actebook="closed";
        public string category = "category",actcategroy="closed";
        public string user = "user",actuser="closed";
        public string roles = "roles",actroles="closed";
        protected void Page_Load(object sender, EventArgs e)
        {
            string obj = HttpContext.Current.Request.Path;
            switch (obj.ToLower())
            {
                case "/cms/cmsproducts.aspx":
                case "/cms/default.aspx":
                    ebook = "selected";
                    actebook = "opened";
                    break;
                case "/cms/cmscategories.aspx":
                    category = "selected";
                    actcategroy = "opened";
                    break;
                case "/cms/cmsusers.aspx":
                    user = "selected";
                    actuser = "opened";
                    break;
                case "/cms/cmsroles.aspx":
                    roles = "selected";
                    actroles = "opened";
                    break;
                default:
                    ebook = "selected";
                    actebook = "opened";
                    break;
            }
        }
    }
}