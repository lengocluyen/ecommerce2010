using System;
using System.Collections;
using System.Collections.Generic;
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

namespace ECommerce2010.UserControl.Left
{
    public partial class Left : System.Web.UI.UserControl
    {
        public string language = "en";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptCategory.DataSource = Category.Find(p => p.ParentID == 0);
                rptCategory.DataBind();
                HandleLangue();
            }
            
        }
        public void HandleLangue()
        {
            string lang = QueryHelper.GetQueryString(Request, "lang");
            switch (lang)
            {
                case "po":
                    tLeftTitle1.InnerText = "Thoi Trang";
                    language = "po";
                    break;
                case "en":
                default:
                    tLeftTitle1.InnerText = "Fashion & Live";
                    language = "en";
                    break;
            }
        }
        public string GetNameCategory(object ob)
        {
            int lg = (int)Languages.English;
            string lang = QueryHelper.GetQueryString(Request, "lang");
            switch (lang)
            {
                case "po":
                    lg = (int)Languages.Poland;
                    break;
                case "en":
                default:
                    lg = (int)Languages.English;
                    break;
            }
            return Utils.GetStringInString(ob.ToString(), Utils.flychips, lg);
        }
        public List<Category> GetSubCategory(object ob)
        {
            int id = int.Parse(ob.ToString());
            return Category.Find(p => p.ParentID == id);
        }
    }
}