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
using SubSonic.Schema;
namespace ECommerce2010.UserControl.Right
{
    public partial class Right : System.Web.UI.UserControl
    {
        public string language = "en";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        public void LoadData()
        {
               
           string categoryID = QueryHelper.GetQueryString(Request,"value");
           if (QueryHelper.GetQueryString(Request, "do") == "productdetail")
           {
               int id = LibConvert.ConvertToInt(QueryHelper.GetQueryString(Request,"value"),0);
               if(id!=0)
                    categoryID = Product.Single(id).CategoryID.ToString();
           }
            this.LoadProductPaging(Product.GetProductPaging(categoryID,pager.CurrentIndex, pager.PageSize));
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            pager.Command += new CommandEventHandler(pager_Command);
        }
        void pager_Command(object sender, CommandEventArgs e)
        {
            LoadData();
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
        public void LoadProductPaging(PagedList<Product> products)
        {
            PagedList<Product> list = products;
            if (pager != null)
            {
                pager.ItemCount = list.TotalCount;
            }
            Repeater1.DataSource = products;
            Repeater1.DataBind();
        }
    }
}