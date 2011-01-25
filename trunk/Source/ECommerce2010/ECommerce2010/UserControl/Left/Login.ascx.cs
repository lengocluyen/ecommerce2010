using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ECommerce2010.Core;
using StructureMap;

namespace ECommerce2010.UserControl.Left
{
    public partial class Login : System.Web.UI.UserControl
    {
        public IUserSession _userSession;
        public IRedirector _redirector;
        public IConfiguration _configuration;
        string language = "en";
        public bool IsEnglish()
        {
            string lang = QueryHelper.GetQueryString(Request, "lang");

            switch (lang)
            {
                case "po":
                    language = "po";
                    return false;
                case "en":
                default:
                    language = "en";
                    return true;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            _redirector = ObjectFactory.GetInstance<IRedirector>();
            _userSession = ObjectFactory.GetInstance<IUserSession>();
            _configuration = ObjectFactory.GetInstance<IConfiguration>();
            if (_userSession.CurrentMember != null)
            {
                pnLogin.Visible = false;
                pnInfoUser.Visible = true;
                HandleLanguage2();
                lblEmail.Text = _userSession.Username;
                lblTime.Text = _userSession.TimeUserLogin.ToString("HH:MM:ss - dd/mm/yyyy");
            }
            else
            {
                pnLogin.Visible = true;
                pnInfoUser.Visible = false;
                HandleLanguage1();
            }
        }
        public void HandleLanguage1()
        {
            bool isEnglish = IsEnglish();
            lbEmail.Text = isEnglish ? Resources.English.email : Resources.Poland.email;
            lbPassword.Text = isEnglish ? Resources.English.password: Resources.Poland.password;
            tLeftTitle2.InnerText = isEnglish ? Resources.English.login : Resources.Poland.login;
            btlogin.Text = isEnglish ? Resources.English.login : Resources.Poland.login;
        }
        public void HandleLanguage2()
        {
            bool isEnglish = IsEnglish();
            lWelcome.Text = isEnglish ? Resources.English.welcome : Resources.Poland.welcome;
            lTime.Text = isEnglish ? Resources.English.Loginat : Resources.Poland.Loginat;
            btLogout.Text = isEnglish ? Resources.English.logout : Resources.Poland.logout;
        }
        protected void btLogout_Click(object sender, EventArgs e)
        {
            _userSession.CurrentMember = null;
            _userSession.LoggedIn = false;
            _userSession.Username = "";
            _userSession.RoleCurrentUser = null;
            _userSession.TimeUserLogin = DateTime.Now;
            _redirector.GoToHomePage();
                
        }
        protected void btlogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string pass = txtPassword.Text.Trim();
            User a = User.Find(p => p.Email == email && p.Password == pass)[0];
            if (a != null)
            {
                _userSession.CurrentMember = a;
                _userSession.LoggedIn = true;
                _userSession.Username = a.Email;
                _userSession.RoleCurrentUser = Role.Single(a.RoleID);
                _userSession.TimeUserLogin = DateTime.Now;
                string loginsuccess = IsEnglish() ? Resources.English.LoginSuccessful : Resources.Poland.LoginSuccessful;
                this.MsgClient.InnerHtml = "<script language='javascript'>window.alert(" + '"' + loginsuccess + '"' + ");</script>";
                if (_userSession.ListCart.Count > 0)
                {
                    Response.Redirect(_configuration.RootURL + "Default.aspx?lang=" + language + "&do=yourcart");
                }
                string act = Request.Params["act"];
                string detail = Request.Params["detail"];
                
                string link = "";
                if (act != null)
                {
                    link += "?act=" + act;
                    if (detail != null)
                        link += "&detail=" + detail;
                }
                Response.Redirect(Request.Url.AbsolutePath + link);
            }
            else
                this.MsgClient.InnerHtml = "<script language='javascript'>window.location = \"Default.aspx\";</script>";
        }
    }
}