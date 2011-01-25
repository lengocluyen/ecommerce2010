using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ECommerce2010.Core;
using System.Globalization;

namespace ECommerce2010.UserControl.Right
{
    public partial class Register : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            this.InitControl();
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
        public void InitControl()
        {
            bool isEnglish = IsEnglish();
            lbRegister.Text = isEnglish ? Resources.English.register : Resources.Poland.register;
            tFirstName.InnerText = isEnglish ? Resources.English.firstName : Resources.Poland.firstName;
            tLastName.InnerText = isEnglish ? Resources.English.lastName : Resources.Poland.lastName;
            tEmail.InnerText = isEnglish ? Resources.English.email : Resources.Poland.email;

            tPassword.InnerText = isEnglish ? Resources.English.password : Resources.Poland.password;
            tRePassword.InnerText = isEnglish ? Resources.English.repassword : Resources.Poland.repassword;
            tSex.InnerText = isEnglish ? Resources.English.sex : Resources.Poland.sex;
            tBirthDay.InnerText = isEnglish ? Resources.English.birthday : Resources.Poland.birthday;
            tPhone.InnerText = isEnglish ? Resources.English.Phone : Resources.Poland.Phone;
            tAddress.InnerText = isEnglish ? Resources.English.address : Resources.Poland.address;
            tIndentify.InnerText = isEnglish ? Resources.English.identify : Resources.Poland.identify;
            btButton.Text = isEnglish ? Resources.English.submit : Resources.Poland.submit;
            tCountry.InnerText = isEnglish ? Resources.English.country : Resources.Poland.country;
            this.rblSex.Items[0].Text = isEnglish ? Resources.English.male : Resources.Poland.male;
            this.rblSex.Items[1].Text = isEnglish ? Resources.English.female : Resources.Poland.female;

            int minYear = DateTime.Now.Year - 100;
            int maxYear = DateTime.Now.Year - 10;
            this.scriptEpoch.InnerHtml = "<script type=\"text/javascript\" src=\"Js/epoch_classes.js\"></script>";
            this.scriptEpoch.InnerHtml += "<script type=\"text/javascript\" language=\"javascript\">var dp_cal; window.onload = function () {dp_cal  = new Epoch('epoch_popup','popup',document.getElementById('" + this.popup_container.ClientID + "'),false," + minYear.ToString() + "," + maxYear.ToString() + ");};</script>";

            // Validation        
            this.rfvPassword.ErrorMessage = "*";
            this.rfvName.ErrorMessage = "*";
            this.rfvLastName.ErrorMessage = "*";
            this.rfvAddress.ErrorMessage = "*";
            this.RegularExpressionValidatorEmail.ErrorMessage = "*";
            this.cpvPassword.ErrorMessage = "*";

            this.RegularExpressionValidatorDate.ErrorMessage = "*";
            this.RegularExpressionValidatorDate.ValidationExpression = "\\b(0?[1-9]|[12][0-9]|3[01])[- /.](0?[1-9]|1[012])[- /.](19|20)?[0-9]{2}\\b";

            //Get all Country
            Dictionary<string, string> objDic = new Dictionary<string, string>();

            foreach (CultureInfo ObjCultureInfo in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                RegionInfo objRegionInfo = new RegionInfo(ObjCultureInfo.Name);
                if (!objDic.ContainsKey(objRegionInfo.EnglishName))
                {
                    objDic.Add(objRegionInfo.EnglishName, objRegionInfo.TwoLetterISORegionName.ToLower());
                }
            }

            var obj = objDic.OrderBy(p => p.Key);
            foreach (KeyValuePair<string, string> val in obj)
            {
                ddlCountries.Items.Add(new ListItem(val.Key, val.Value));
            }
        }

        protected void btButton_Click(object sender, EventArgs e)
        {
            bool isEnglish = IsEnglish();
            if (Session["Captcha"].ToString() != this.txtCaptcha.Text.Trim())
            {
                lbCaptcha.Text =  isEnglish?Resources.English.WrongCaptcha:Resources.Poland.WrongCaptcha;
                return;
            }
            if (this.txtEmail.Text.Trim() != "" && this.txtPassword.Text.Length > 6 && this.txtName.Text.Trim() != "" && this.txtLastName.Text.Trim() != "" &&
                this.popup_container.Text.Trim() != "" && this.txtAddress.Text.Trim() != "" && this.txtPhone.Text.Trim() != "")
            {
                string email = this.txtEmail.Text.Trim();
                string password = this.txtPassword.Text;
                string firstName = this.txtName.Text.Trim();
                string lasname = this.txtLastName.Text.Trim();

                DateTime dateAdded = DateTime.Now;
                string dateb = this.popup_container.Text.Trim();
                DateTime dateOfBirth = DateTime.Parse(Utils.ChangeDateFormat(dateb));
                string address = this.txtAddress.Text.Trim();
                string phone = this.txtPhone.Text.Trim();
                bool sex = false;
                string country = ddlCountries.Text.Trim();
                if (this.rblSex.Items[1].Selected)
                    sex = true;
                ECommerce2010.Core.User user = new User();
                user.Email = email;
                user.Password = password;
                user.FirstName = firstName;
                user.LastName = lasname;
                user.Phone = phone;
                user.Address = address;
                user.Sex = sex;
                user.Country = country;
                user.Created = dateAdded;
                user.Birthday = dateOfBirth;
                user.IsEnabled = true;

                user.RoleID =(int) ListRole.PUBLIC;
                if(User.Find(p=>p.Email==email).Count>0)
                {
                    string s1 = isEnglish ? Resources.English.DuplicateEmail : Resources.Poland.DuplicateEmail;
                    this.MsgClient.InnerHtml = "<script language='javascript'>window.alert(" + '"' +s1+ '"' + ");</script>";
                    return;
                }
                if (User.Add(user) != null)
                {
                    string s2 = isEnglish ? Resources.English.RegisterSuccessful : Resources.Poland.RegisterSuccessful;
                    this.MsgClient.InnerHtml = "<script language='javascript'>window.alert(" + '"' + s2 + '"' + ");</script>";
                    this.MsgClient.InnerHtml += "<script language='javascript'>window.location = \"" + Request.Url.AbsolutePath + "?act=login" + "\";</script>";
                }
                else
                {
                    string s3 = isEnglish ? Resources.English.RegisterUnsuccessful : Resources.Poland.RegisterUnsuccessful;
                    this.MsgClient.InnerHtml = "<script language='javascript'>window.alert(" + '"' + s3 + '"' + ");</script>";
                }
            }

        }
    }
}