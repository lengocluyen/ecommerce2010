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

namespace ECommerce2010
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            this.LoadControl();
        }
        protected void LoadControl()
        {
            string act = QueryHelper.GetQueryString(Request,"do");
            switch (act)
            {
                case "register":
                    idContent.LoadControlRegister(IsEnglish() ? Resources.English.register : Resources.Poland.register);
                    break;
                case "contactus":
                    idContent.LoadControlContactUs(IsEnglish() ? Resources.English.contactUs : Resources.Poland.contactUs);
                    break;
                case "productdetail":
                    idContentExtra.Visible = true;
                    idContent.LoadControlProductDetails(IsEnglish() ? Resources.English.productDetails : Resources.Poland.productDetails);
                    idContentExtra.LoadControlProductNew(IsEnglish() ? Resources.English.otherPoduct : Resources.Poland.otherPoduct);
                    break;
                case "yourcart":
                    idContent.LoadControlYourCart(IsEnglish() ? Resources.English.yourcart : Resources.Poland.yourcart);
                    break;
                case "category":
                default:
                    idContent.LoadControlProductNew(IsEnglish()?Resources.English.newProduct:Resources.Poland.newProduct);
                    break;
            }
        }
        public bool IsEnglish()
        {

            string lang = QueryHelper.GetQueryString(Request, "lang");
            switch (lang)
            {
                case "po":
                    return false;
                case "ed":
                default:
                    return true;
            }
        }
    }
}
