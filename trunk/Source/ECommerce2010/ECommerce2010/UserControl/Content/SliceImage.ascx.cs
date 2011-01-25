using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ECommerce2010.Core;

namespace ECommerce2010.UserControl.Content
{
    public partial class SliceImage : System.Web.UI.UserControl
    {
        public string language = "en";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.rptImage.DataSource = Product.All().OrderByDescending(p => p.CreateDate).Take(20);
            this.rptImage.DataBind();
        }
        public string GetObjectByLanguage(object ob)
        {
            int lg = (int)Languages.English;
            string lang = QueryHelper.GetQueryString(Request, "lang");
            switch (lang)
            {
                case "po":
                    lg = (int)Languages.Poland;
                    language = "po";
                    break;
                case "en":
                default:
                    lg = (int)Languages.English;
                    language = "en";
                    break;
            }
            return Utils.GetStringInString(ob.ToString(), Utils.flychips, lg);
        }
    }
}