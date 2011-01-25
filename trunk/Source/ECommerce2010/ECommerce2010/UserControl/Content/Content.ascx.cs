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

namespace ECommerce2010.UserControl.Content
{
    public partial class Content : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void LoadControlRegister(string title)
        {
            ttitleContent.InnerText = title;
            phContent.Controls.Add(Page.LoadControl("./UserControl/Right/Register.ascx"));
        }
        public void LoadControlProductNew(string title)
        {
            ttitleContent.InnerText = title;
            phContent.Controls.Add(Page.LoadControl("./UserControl/Right/Right.ascx"));
        }
        public void LoadControlContactUs(string title)
        {
            ttitleContent.InnerText = title;
            phContent.Controls.Add(Page.LoadControl("./UserControl/Right/ContactUs.ascx"));
        }
        public void LoadControlProductDetails(string title)
        {
            ttitleContent.InnerText = title;
            phContent.Controls.Add(Page.LoadControl("./UserControl/Right/DetailProduct.ascx"));
        }
        public void LoadControlYourCart(string title)
        {
            ttitleContent.InnerText = title;
            phContent.Controls.Add(Page.LoadControl("./UserControl/Right/YourCart.ascx"));
        }
    }
}