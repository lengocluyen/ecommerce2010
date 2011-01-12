using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ECommerce2010.Core;

namespace ECommerce2010.CMS.UCFunction
{
    public partial class AddEditRole : System.Web.UI.UserControl
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
            //if (Session["Membership"] != null && !(Session["Membership"] as Agri_UserInfo).IsAdministrator())
            //this.btnOK.Visible = true;

            // Validation        
            this.rfvName.ErrorMessage = "*";
            // Job
            if (Request.Params["aid"] != null)
                aid = int.Parse(Request.Params["aid"]);
            switch (uDo)
            {
                case "edit":
                    Role role = Role.Single(aid);
                    if (role == null)
                        return;

                    this.txtName.Text = role.Name;
                    break;
                case "add":
                    break;
                default:
                    break;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = this.txtName.Text.Trim();
            if (uDo == "edit")
            {
                Role role = Role.Single(aid);
                role.Name = txtName.Text;
                Role.Update(role);
            }
            else if (uDo == "add")
            {
                Role role = new Role();
                role.Name = txtName.Text;
                Role.Add(role);
            }
            Response.Redirect("CMSRoles.aspx");
        }
    }
}