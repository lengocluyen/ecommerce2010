using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ECommerce2010.Core;
using SubSonic.Security;

namespace ECommerce2010.CMS.UCFunction
{
    public partial class AddEditUser : System.Web.UI.UserControl
    {
        public string header = "";
        string uDo = "";
        public int aid = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            uDo = Request.Params["do"];
            if (uDo != null)
                InitControl();
        }
        void InitControl()
        {
            List<Role> roles = Role.All().ToList();
            this.ddlRoles.Items.Clear();
            foreach (Role r in roles)
                this.ddlRoles.Items.Add(r.Name);

            ////if (Session["Membership"] != null && !(Session["Membership"] as Agri_UserInfo).IsAdministrator())
            //this.btnOK.Visible = true;

            // Validation        
            
            // Job
            if (Request.Params["aid"] != null)
                aid = int.Parse(Request.Params["aid"]);
            switch (uDo)
            {
                case "edit":
                    User user = User.Single(aid);
                    if (user == null)
                        return;

                    this.txtEmail.Text = user.Email;
                    this.ddlRoles.Text = Role.Single(user.RoleID).Name;
                    this.cbActive.Checked = user.IsEnabled;
                    break;
                case "add":
                    break;
                default:
                    break;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string email = this.txtEmail.Text.Trim();
            string password = this.txtPassword.Text.Trim();
            
            bool checkbox = cbActive.Checked;
            string pass = Cryptography.Encrypt(password, email);
            int idRole = -1;
            try
            {
                idRole = Role.Find(r => r.Name == ddlRoles.Text.Trim()).FirstOrDefault().RoleID;
            }
            catch { idRole = 0; }
            if (uDo == "edit")
            {
                User user = User.Single(aid);
                if (User.Single(u => u.Email == email&&user.UserID!=aid) != null)
                {
                    this.idNotice.Visible = true;
                    return;
                }
                user.Email = email;
                if (password != "")
                    user.Password = user.Password;
                else
                    user.Password = password;
                user.RoleID = idRole;
                user.IsEnabled = checkbox;

                User.Update(user);
            }
            else if (uDo == "add")
            {
                User user = new User();
                if (User.Single(u=>u.Email==email)!=null)
                {
                    this.idNotice.Visible = true;
                    return;
                }
                user.Email = email;
                user.Password = pass;
                user.RoleID = idRole;
                user.IsEnabled = checkbox;
                User.Add(user);
            }
            Response.Redirect("CMSUsers.aspx");
        }
    }
}