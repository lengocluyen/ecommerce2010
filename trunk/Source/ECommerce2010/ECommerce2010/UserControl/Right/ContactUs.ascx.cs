using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ECommerce2010.Core;
using StructureMap;

namespace ECommerce2010.UserControl.Right
{
    public partial class ContactUs : System.Web.UI.UserControl
    {
        IConfiguration _configuration;
        protected void Page_Load(object sender, EventArgs e)
        {
            _configuration = ObjectFactory.GetInstance<IConfiguration>();
            HandleLanguage();
        }
        public bool IsEnglish()
        {
            string lang = QueryHelper.GetQueryString(Request, "lang");

            switch (lang)
            {
                case "po":
                    return false;
                case "en":
                default:
                    return true;
            }
        }
        public void HandleLanguage()
        {
            bool isEng = IsEnglish();
            lblTitle.Text = isEng ? Resources.English.contactUs : Resources.Poland.contactUs;
            lblAddress.Text = isEng ? Resources.English.address : Resources.Poland.address;
            lblEmail.Text = isEng ? Resources.English.email : Resources.Poland.email;
            lblName.Text = isEng ? Resources.English.name : Resources.Poland.name;
            lblPhone.Text = isEng ? Resources.English.Phone : Resources.Poland.Phone;
            lbleContent.Text = isEng ? Resources.English.content : Resources.Poland.content;
            btButtonHK.Text = isEng ? Resources.English.submit : Resources.Poland.submit;
            
        }
        protected void btButton_Click(object sender, EventArgs e)
        {
            try
            {
                 bool isEng = IsEnglish();
                Contact a = new Contact();
                a.Name = this.txtName.Text.Trim();
                a.Email = this.txtEmail.Text.Trim();
                a.Phone = this.txtPhone.Text.Trim();
                a.Address = this.txtAddress.Text.Trim();
                a.CreatedDate = DateTime.Now;
                a.Content = this.txtContent.Text.Trim();
                a.Active = false;
                string s = ""; 
                if (Contact.Add(a)!=null)
                {
                    User admin = User.Find(p => p.Email == _configuration.EmailAdmin)[0];
                    //Response.Write(@"<meta http-equiv=""Refresh"" content=""0;URL=" + Request.Url.ToString().Substring(0, Request.Url.ToString().LastIndexOf("/")) + @"/"" />");
                    s = isEng ? Resources.English.customerContact : Resources.Poland.customerContact;
                    if (SendMail.Send(admin.Email, s, txtName.Text + "\n" + txtAddress.Text + "\n" + txtEmail.Text + "\n" + txtPhone.Text + "\n" + txtContent.Text) == 1)
                    {
                        s = isEng ? Resources.English.contactusSuccessfulwewillrespondtoyoulater : Resources.Poland.contactusSuccessfulwewillrespondtoyoulater;
                        txtEmail.Text = "";
                    }
                    this.messError.InnerHtml = @"<script>alert('" + s + "'); </script>";
                }

                else
                {
                    s = isEng ? Resources.English.serveroverloadedpleasetryagainlater : Resources.Poland.serveroverloadedpleasetryagainlater;
                    this.messError.InnerHtml = @"<script language='javascript'>window.alert("" Server quá tải, vui lòng thử lại sau! "");</script>";
                }
            }
            catch { }
        }
    }
}