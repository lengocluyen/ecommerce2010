using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StructureMap;
using ECommerce2010.Core;
using SubSonic.Schema;

namespace ECommerce2010.CMS
{
    public partial class CMSCategories : System.Web.UI.Page
    {
       public IConfiguration _configuration;
       public CMSCategories()
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
            this.LoadCategoryPaging(ECommerce2010.Core.Category.GetCategoryPaging(pager.CurrentIndex, pager.PageSize));
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadCategoryPaging(ECommerce2010.Core.Category.GetCategoryPaging(pager.CurrentIndex, pager.PageSize));
            }
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
                            ECommerce2010.Core.Category.Delete(adsID);
                            this.PreRenderComplete += new EventHandler(AdminCP_Course_PreRenderComplete);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        void AdminCP_Course_PreRenderComplete(object sender, EventArgs e)
        {
            Response.Redirect("~/CMS/CMSCategories.aspx");
        }
        public void btApply_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem i in rptCategories.Items)
            {
                CheckBox cbox = i.FindControl("idCheck") as CheckBox;
                if (cbox.Checked)
                {
                    HiddenField hfield = i.FindControl("idHiddenField") as HiddenField;
                    int id = int.Parse(hfield.Value);
                    //Thực thi xóa user ở đay
                    //xóa các đối tượng được chọn
                    if (ddlAct.Items[0].Selected)
                    {
                        ECommerce2010.Core.Category.Delete(int.Parse(hfield.Value.ToString()));
                    }
                    //kích hoạt các đối tượng được chọn
                    if (ddlAct.Items[1].Selected)
                    {
                        ECommerce2010.Core.Category category = ECommerce2010.Core.Category.Single(int.Parse(hfield.Value.ToString()));
                        category.IsActive = true;
                        ECommerce2010.Core.Category.Update(category);
                    }
                    if (ddlAct.Items[2].Selected)
                    {
                        ECommerce2010.Core.Category category = ECommerce2010.Core.Category.Single(int.Parse(hfield.Value.ToString()));
                        category.IsActive = false;
                        ECommerce2010.Core.Category.Update(category);
                    }

                }
            }
            this.PreRenderComplete += new EventHandler(AdminCP_Course_PreRenderComplete);
        }
        //Method Fucntion

        void LoadControls()
        {
            Control addEditCategory = (Control)Page.LoadControl("~/CMS/UCFunction/AddEditCategory.ascx");
            this.phAddEditCategory.Controls.Add(addEditCategory);
        }
        public void LoadCategoryPaging(PagedList<Category> categories)
        {
            PagedList<Category> list = categories;
            if (pager != null)
            {
                pager.ItemCount = list.TotalCount;
            }
            rptCategories.DataSource = categories;
            rptCategories.DataBind();
        }
        public string GetCategoryByID(object id)
        {
            string name="";
            try {
                name = Category.Single(int.Parse(id.ToString())).Name;
            }
            catch { }
            return id.ToString()!="0"? name:"Root";
        }
       
    }
}
