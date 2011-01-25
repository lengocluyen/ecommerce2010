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
using System.Globalization;
using ECommerce2010.Core;
namespace ECommerce2010
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.HandleLanguage();
        }
        public string language = "en";
        protected void HandleLanguage()
        {
           
            string lang = QueryHelper.GetQueryString(Request, "lang");
            switch (lang)
            {
                case "po":
                    tHome.InnerText = Resources.Poland.home;
                    tContact.InnerText = Resources.Poland.contact;
                    tRegister.InnerText = Resources.Poland.register;
                    tselectLang.InnerText = Resources.Poland.selectLanguage;
                    tSearch.InnerText = Resources.Poland.search;
                    tAddress.InnerText = Resources.Poland.address;
                    tPhone.InnerText = Resources.Poland.Phone;
                    tEmail.InnerText = Resources.Poland.email;
                    tDesgnedby.InnerText = Resources.Poland.designedby;
                    tRegister.Attributes.Add("href","Default.aspx?lang=po&do=register");
                    tContact.Attributes.Add("href", "Default.aspx?lang=po&do=contactus");
                    tHome.Attributes.Add("href", "Default.aspx?lang=po");
                    tyourCart.Attributes.Add("href", "Default.aspx?lang=po&do=yourcart");
                    language = "po";
                    if (Request.Url.PathAndQuery == Request.Url.AbsolutePath) return;
                    aEnglish.Attributes.Add("href", Request.Url.AbsoluteUri.Replace("lang=po", "lang=en"));
                    aPoland.Attributes.Add("href", Request.Url.AbsoluteUri.Replace("lang=en", "lang=po"));
                    break;
                case "en":
                default:
                    tHome.InnerText = Resources.English.home;
                    tContact.InnerText = Resources.English.contact;
                    tRegister.InnerText = Resources.English.register;
                    tselectLang.InnerText = Resources.English.selectLanguage;
                    tSearch.InnerText = Resources.English.search;
                    tAddress.InnerText = Resources.English.address;
                    tPhone.InnerText = Resources.English.Phone;
                    tEmail.InnerText = Resources.English.email;
                    tDesgnedby.InnerText = Resources.English.designedby;
                    tRegister.Attributes.Add("href", "Default.aspx?lang=en&do=register");
                    tContact.Attributes.Add("href", "Default.aspx?lang=en&do=contactus");
                    tHome.Attributes.Add("href", "Default.aspx?lang=en");
                    tyourCart.Attributes.Add("href", "Default.aspx?lang=en&do=yourcart");
                    language = "en";
                    if (Request.Url.PathAndQuery == Request.Url.AbsolutePath) return;
                    aPoland.Attributes.Add("href", Request.Url.AbsoluteUri.Replace("lang=en","lang=po"));
                    aEnglish.Attributes.Add("href", Request.Url.AbsoluteUri.Replace("lang=po","lang=en"));
                    break;

            }

        }
    }
}
