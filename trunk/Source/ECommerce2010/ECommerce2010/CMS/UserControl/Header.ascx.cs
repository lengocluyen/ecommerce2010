using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StructureMap;
using SubSonic;
using ECommerce2010.Core;

namespace ECommerce2010.CMS.UserControl
{
    public partial class Header : System.Web.UI.UserControl
    {
        public IUserSession _userSession;

        public Header()
        {
            _userSession = ObjectFactory.GetInstance<IUserSession>();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}