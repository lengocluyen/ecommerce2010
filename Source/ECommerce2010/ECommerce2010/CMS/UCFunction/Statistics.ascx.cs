using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ECommerce2010.Core;
using StructureMap;
using SubSonic;

namespace ECommerce2010.CMS.UCFunction
{
    public partial class Statistics : System.Web.UI.UserControl
    {
        public int totalBook = 0;
        public long totalDownload = 0;
        public IUserSession _userSession;
        public Statistics()
        {
            _userSession = ObjectFactory.GetInstance<IUserSession>();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                //totalBook = Product.All().Count();
                //rpCategory.DataSource = Category.All();
                //rpCategory.DataBind();
            }
        }
        public string GetCountBookByCategory(object id)
        {
            return Product.Find(p=>p.CategoryID==int.Parse(id.ToString())).Count().ToString();
        }

       
    }
}