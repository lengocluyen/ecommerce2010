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
namespace ECommerce2010.UserControl.Right
{
    public partial class DetailProduct : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadDefault();
        }
        protected Product LoadDefault()
        {
            int annID = GetAnnID();
            Product ann = new Product();
            if (annID > 0)
            {
                 ann = Product.Single(annID);
            }
            return ann;
        }
   
        protected int GetAnnID()
        {
            if (Request.QueryString["id"] != null)
            {
                int annID = int.Parse(Request.QueryString["id"]);
                return annID;
            }
            else
                Response.Redirect("Default.aspx");
            return 0;
        }
    }
}