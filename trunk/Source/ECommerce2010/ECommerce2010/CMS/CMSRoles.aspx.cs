using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ECommerce2010.Core;
using StructureMap;
using SubSonic.Schema;

namespace ECommerce2010.CMS
{
    public partial class CMSRoles : System.Web.UI.Page
    {
        public IConfiguration _configuration;
        public CMSRoles()
        {
            _configuration = ObjectFactory.GetInstance<IConfiguration>();
        }
        protected override void OnInit(EventArgs e)
        {

            base.OnInit(e);
            pager.Command += new CommandEventHandler(pager_Command);
        }

        void pager_Command(object sender, CommandEventArgs e)
        {
            LoadRolePaging(Role.GetRolePaging(pager.CurrentIndex, pager.PageSize));
        }
        public void LoadRolePaging(PagedList<Role> roles)
        {
            PagedList<Role> list = roles;
            if (pager != null)
            {
                pager.ItemCount = list.TotalCount;
            }
            rptRoles.DataSource = roles;
            rptRoles.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRolePaging(Role.GetRolePaging(pager.CurrentIndex, pager.PageSize));
                if (Request.Params["do"] != null)
                {
                    string aDo = Request.Params["do"];
                    switch (aDo)
                    {
                        case "edit":
                            if (Request.Params["aid"] != null)
                                LoadControls();
                            break;
                        case "add":
                            LoadControls();
                            break;
                        case "del":
                            if (Request.Params["aid"] != null)
                            {
                                int adsID = 0;
                                try
                                {
                                    adsID = int.Parse(Request.Params["aid"].ToString());
                                }
                                catch { }
                                ECommerce2010.Core.Role.Delete(adsID);
                                this.PreRenderComplete += new EventHandler(AdminCP_Course_PreRenderComplete);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        void AdminCP_Course_PreRenderComplete(object sender, EventArgs e)
        {
            Response.Redirect("/CMS/CMSRoles.aspx");
        }
        void LoadControls()
        {
            Control addEditCourse = (Control)Page.LoadControl("~/CMS/UCFunction/AddEditRole.ascx");
            this.phAddEditRole.Controls.Add(addEditCourse);
        }
        public void btApply_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem i in rptRoles.Items)
            {
                CheckBox cbox = i.FindControl("idCheck") as CheckBox;
                if (cbox.Checked)
                {
                    HiddenField hfield = i.FindControl("idHiddenField") as HiddenField;
                    int id = int.Parse(hfield.Value);
                    //Thực thi xóa ở đay
                }
            }
        }

        protected void rptRoles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
        }
    }
}
