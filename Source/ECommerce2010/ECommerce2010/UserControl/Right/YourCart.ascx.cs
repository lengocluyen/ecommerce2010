using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ECommerce2010.Core;
using System.Collections.Generic;
using StructureMap;
namespace ECommerce2010.UserControl.Right
{
    public partial class YourCart : System.Web.UI.UserControl
    {
        protected IUserSession _userSession;
        protected IRedirector _redirector;
        protected IConfiguration _configuration;
        public string language = "en";
        public decimal total = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            _userSession = ObjectFactory.GetInstance<IUserSession>();
            _redirector = ObjectFactory.GetInstance<IRedirector>();
            _configuration = ObjectFactory.GetInstance<IConfiguration>();
            HandleLanguage();

            Repeater1.DataSource = _userSession.ListCart;
            Repeater1.DataBind();
            
        }
        protected void btPayment_Click(object sender, EventArgs e)
        {
            if (_userSession.ListCart.Count <= 0) return;
            try
            {
                if (_userSession.CurrentMember != null)
                {
                    Order od = new Order();
                    od.OrderDay = DateTime.Now;
                    od.UserID = _userSession.CurrentMember.UserID;
                    od.Total = (int)total;
                    Order.Add(od);

                    foreach (YourCarts i in _userSession.ListCart)
                    {
                        OrderDetail a = new OrderDetail();
                        a.ProductID = i.Item.ProductID;
                        a.Qualitity = i.Soluong;
                        a.OrderID = od.OrderID;
                        a.UnitPrice = i.Item.Price * i.Soluong;
                        OrderDetail.Add(a);
                    }
                    _userSession.ListCart.Clear();
                    string s1 = IsEnglish() ? Resources.English.AnnounceOrderSuccesful : Resources.Poland.AnnounceOrderSuccesful;
                    this.divMess.InnerHtml = "<script language='javascript'>window.alert(" + '"' + s1 + '"' + ");</script>";
                }
                else
                {
                    string s1 = IsEnglish() ? Resources.English.AnnounceRegisterMember : Resources.Poland.AnnounceRegisterMember;
                    string url = _configuration.RootURL + "Default.aspx?lang=" + language + "&do=register";
                    this.divMess.InnerHtml = "<script language='javascript'>if(confirm('" + s1 + "'))window.location='" + url + "';else window.location='" + _configuration.RootURL + "'</script>";
                    //Response.Redirect("~/Default.aspx?lang="+language+"&do=register");
                }
            }
            catch { }
        }
        protected void btContinueShopping_Click(object sender, EventArgs e)
        {
            _redirector.GoToHomePage();
        }
        protected void btUpdate_Click(object sender, EventArgs e)
        {
            if (_userSession.ListCart.Count <= 0) return;
            foreach (RepeaterItem i in Repeater1.Items)
            {
                TextBox txtBox = i.FindControl("txtQuantity") as TextBox;
                if (txtBox == null) return;
                
                    HiddenField hfield = i.FindControl("dfID") as HiddenField;
                    int id = int.Parse(hfield.Value);
                    int qualitity = LibConvert.ConvertToInt(txtBox.Text.Trim(), 0);
                    this.UpdateCart(id, qualitity);
            }
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        protected void btDelete_Click(object sender, EventArgs e)
        {
            if (_userSession.ListCart.Count <= 0) return;
            foreach (RepeaterItem i in Repeater1.Items)
            {
                CheckBox cbox = i.FindControl("chkChoice") as CheckBox;
                if (cbox == null) return;
                if (cbox.Checked)
                {
                    HiddenField hfield = i.FindControl("dfID") as HiddenField;
                    int id = int.Parse(hfield.Value);
                    _userSession.ListCart.Remove(this.GetCart(id));
                }
            }
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        protected void btDeleteAll_Click(object sender, EventArgs e)
        {
            if (_userSession.ListCart.Count <= 0) return;
            _userSession.ListCart.Clear();
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        public YourCarts GetCart(int productID)
        {
            foreach(YourCarts i in _userSession.ListCart)
            {
                if(i.Item.ProductID==productID)
                    return i;
            }
            return null;
        }
        public void UpdateCart(int productID,int qua)
        {
            for (int i=0;i<_userSession.ListCart.Count;i++)
            {
                if (_userSession.ListCart[i].Item.ProductID == productID)
                {
                    _userSession.ListCart[i].Soluong = qua;
                    return;
                }
            }
            return;
        }
        public void HandleLanguage()
        {
            bool isEng = IsEnglish();
            lblImage.Text = isEng ? Resources.English.photo : Resources.Poland.photo;
            lblPrice.Text = isEng ? Resources.English.Price : Resources.Poland.Price;
            lblProductName.Text = isEng ? Resources.English.NameProduct : Resources.Poland.NameProduct;
            lblQualitity.Text = isEng ? Resources.English.Qualitity : Resources.Poland.Qualitity;
            lblUnitPrice.Text = isEng ? Resources.English.UnitPrice : Resources.Poland.UnitPrice;
            lblSelect.Text = isEng ? Resources.English.Select : Resources.Poland.Select;
            lblTotal.Text = isEng ? Resources.English.Total : Resources.Poland.Total;
            btContinueShopping.Text = isEng ? Resources.English.ContinueShopping : Resources.Poland.ContinueShopping;
            btDelete.Text = isEng ? Resources.English.Delete : Resources.Poland.Delete;
            btDeleteAll.Text = isEng ? Resources.English.DeleteAll : Resources.Poland.DeleteAll;
            btPayment.Text = isEng ? Resources.English.Payment : Resources.Poland.Payment;
            btUpdate.Text = isEng ? Resources.English.Update : Resources.Poland.Update;
            
        }

        public string GetObjectByLanguage(object ob)
        {
            Product i = ob as Product;
            int lg = (int)Languages.English;
            string lang = QueryHelper.GetQueryString(Request, "lang");
            switch (lang)
            {
                case "po":
                    lg = (int)Languages.Poland;
                    language = "po";
                    break;
                case "en":
                default:
                    lg = (int)Languages.English;
                    language = "en";
                    break;
            }
            return Utils.GetStringInString(i.Name, Utils.flychips, lg);
        }
        public string GetImage(object ob)
        {
            Product i = ob as Product;
            return i.Image;
        }
        public string GetProductID(object ob)
        {
            Product i = ob as Product;
            return i.ProductID.ToString();
        }
        public string GetPrice(object ob)
        {
            Product i = ob as Product;
            return i.Price.ToString();
        }
        public string GetUnitPrice(object ob, object obqua)
        {
             Product i = ob as Product;
            decimal qualitity = LibConvert.ConvertToDecimal(obqua,0);
            total += i.Price * qualitity;
            return (i.Price * qualitity).ToString();
        }
        public bool IsEnglish()
        {

            string lang = QueryHelper.GetQueryString(Request, "lang");
            switch (lang)
            {
                case "po":
                    return false;
                case "ed":
                default:
                    return true;
            }
        }
        
    }
}