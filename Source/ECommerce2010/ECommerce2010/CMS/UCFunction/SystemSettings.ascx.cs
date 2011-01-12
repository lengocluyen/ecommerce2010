using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ECommerce2010.Core;
using StructureMap;
using System.Configuration;
using System.Web.Configuration;

namespace ECommerce2010.CMS.UCFunction
{
    
    public partial class SystemSettings : System.Web.UI.UserControl
    {
        public IConfiguration _configuration;
        public SystemSettings()
        {
            
        }
        public int itemUser = 0;
        public int itemAdmin = 0;
        public string rootURL = "";
        public string rootAdmin = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            _configuration = ObjectFactory.GetInstance<IConfiguration>();
            itemUser = _configuration.ItemperPageUser;
            itemAdmin = _configuration.ItemperPageAdmin;
            rootURL = _configuration.RootURL;
            rootAdmin = _configuration.AdminSiteURL;
            if (QueryHelper.GetQueryString(Request, "type").CompareTo("ItemperPageUser") == 0)
            {
                pnItemUser.Visible = true;
                txtPages.Text = _configuration.ItemperPageUser.ToString();
            }
            else if (QueryHelper.GetQueryString(Request, "type").CompareTo("ItemperPageAdmin") == 0)
            {
                pnItemUser.Visible = true;
                txtPages.Text = _configuration.ItemperPageAdmin.ToString();
            }
            else if (QueryHelper.GetQueryString(Request, "type").CompareTo("RootURL") == 0)
            {
                pnItemUser.Visible = true;
                RangeValidator1.Enabled = false;
                txtPages.Text = _configuration.RootURL.ToString();
            }
            else if (QueryHelper.GetQueryString(Request, "type").CompareTo("AdminSiteURL") == 0)
            {
                pnItemUser.Visible = true;
                RangeValidator1.Enabled = false;
                txtPages.Text = _configuration.AdminSiteURL.ToString();
            }

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            System.Configuration.Configuration configuration = WebConfigurationManager.OpenWebConfiguration("~");
            AppSettingsSection appSettings = (AppSettingsSection)configuration.GetSection("appSettings");
            if (QueryHelper.GetQueryString(Request, "type").CompareTo("ItemperPageUser") == 0)
            {
                pnItemUser.Visible = false;
                //ConfigurationManager.AppSettings.Set("ItemperPageUser", txtPages.Text.Trim());
                if (appSettings != null)
                {
                    appSettings.Settings["ItemperPageUser"].Value = txtPages.Text.Trim();
                    configuration.Save();
                }
            }
            else if (QueryHelper.GetQueryString(Request, "type").CompareTo("ItemperPageAdmin") == 0)
            {
                pnItemUser.Visible = false;
                //ConfigurationManager.AppSettings.Set("ItemperPageAdmin", txtPages.Text.Trim());
                if (appSettings != null)
                {
                    appSettings.Settings["ItemperPageAdmin"].Value = txtPages.Text.Trim();
                    configuration.Save();
                }
            }
            else if (QueryHelper.GetQueryString(Request, "type").CompareTo("RootURL") == 0)
            {
                pnItemUser.Visible = false;
                //ConfigurationManager.AppSettings.Set("RootURL", txtPages.Text.Trim());
                if (appSettings != null)
                {
                    appSettings.Settings["RootURL"].Value = txtPages.Text.Trim();
                    configuration.Save();
                }
            }
            else if (QueryHelper.GetQueryString(Request, "type").CompareTo("AdminSiteURL") == 0)
            {
                pnItemUser.Visible = false;
                //ConfigurationManager.AppSettings.Set("AdminSiteURL", txtPages.Text.Trim());
                if (appSettings != null)
                {
                    appSettings.Settings["AdminSiteURL"].Value = txtPages.Text.Trim();
                    configuration.Save();
                }
            }
            Response.Redirect("../CMS/Default.aspx?do=setting");
        }
    }
}