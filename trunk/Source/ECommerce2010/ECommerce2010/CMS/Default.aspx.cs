using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ECommerce2010.Core;

namespace ECommerce2010.CMS
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            this.HandleAction();
        }
        public void HandleAction()
        {
            if (QueryHelper.GetQueryString(Request, "do") != "")
            {
                string act = QueryHelper.GetQueryString(Request, "do");
                switch (act)
                {
                    case "setting":
                        phContent.Controls.Add(Page.LoadControl("~/CMS/UCFunction/SystemSettings.ascx"));
                        break;
                    default:
                        phContent.Controls.Add(Page.LoadControl("~/CMS/UCFunction/Statistics.ascx"));
                        break;
                }
            }
            else
            {
                phContent.Controls.Add(Page.LoadControl("~/CMS/UCFunction/Statistics.ascx"));
            }
        }
    }
}
