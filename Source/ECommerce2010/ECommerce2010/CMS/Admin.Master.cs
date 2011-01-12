using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SubSonic;
using StructureMap;
using ECommerce2010.Core;

namespace ECommerce2010.CMS
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        private IUserSession _userSession;
        private IRedirector _redirector;
        public Admin()
        {
            _userSession = ObjectFactory.GetInstance<IUserSession>();
            _redirector = ObjectFactory.GetInstance<IRedirector>();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (_userSession.CurrentMember == null || _userSession.RoleCurrentUser.RoleID == Convert.ToInt16(ListRole.PUBLIC) || _userSession.RoleCurrentUser.RoleID == Convert.ToInt16((ListRole.REGISTERED)))
            //{
            //    _redirector.GotoLoginPage();
            //}
        }
    }
}
