using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ECommerce2010.Core;
using SubSonic;
using SubSonic.Security;
using StructureMap;

namespace ECommerce2010.CMS
{
    public partial class Login : System.Web.UI.Page
    {
        protected IUserSession _userSession;
        protected IRedirector _redirector;
        public Login()
        {
            _userSession = ObjectFactory.GetInstance<IUserSession>();
            _redirector = ObjectFactory.GetInstance<IRedirector>();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (QueryHelper.GetQueryString(Request, "do") == "logout")
            {
                _userSession.CurrentMember = null;
                _userSession.Username = null;
                _userSession.TimeUserLogin = DateTime.Now;
                _userSession.RoleCurrentUser = null;
                _userSession.LoggedIn = false;
                _redirector.GoToHomePage();
            }
            if (_userSession.CurrentMember != null && (_userSession.RoleCurrentUser.RoleID == Convert.ToInt16(ListRole.ADMINISTRATOR) || _userSession.RoleCurrentUser.RoleID == Convert.ToInt16((ListRole.MODERATOR))))
            {
                _redirector.GotoAdminPage();
                return;
            }
        }
        public void btn_Click(object sender, EventArgs e)
        {
            string email = txtMail.Text.Trim();
            string pass = txtPassword.Text.Trim();

            pass = Cryptography.Encrypt(pass, email);
            ECommerce2010.Core.User user = ECommerce2010.Core.User.Single(u => u.Email == email && u.Password == pass);
            if (user != null)
            {
                _userSession.CurrentMember = user;
                _userSession.Username = user.Email;
                _userSession.TimeUserLogin = DateTime.Now;
                _userSession.RoleCurrentUser = Role.Single(user.RoleID);
                _userSession.LoggedIn = true;
                _redirector.GotoAdminPage();
            }
            else
            {
                divMessage.Visible = true;
            }
        }
    }
}
