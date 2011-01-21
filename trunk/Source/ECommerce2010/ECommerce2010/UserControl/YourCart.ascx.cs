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
using System.Collections.Generic;
namespace ECommerce2010.UserControl
{
    public partial class YourCart : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserSession userSession = new UserSession();
            // Gan vao
            List<YourCarts> lstCarts = userSession.ListCart;
            Repeater1.DataSource = lstCarts;
            Repeater1.DataBind();
        }

        public decimal UnitPrice(int sl, decimal price)
        {
            return sl * price;
        }
    }
}