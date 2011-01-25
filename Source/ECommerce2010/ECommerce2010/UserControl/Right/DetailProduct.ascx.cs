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
using System.Web.UI.MobileControls;
using System.Collections.Generic;
using StructureMap;
namespace ECommerce2010.UserControl.Right
{
    public partial class DetailProduct : System.Web.UI.UserControl
    {
        public Product products = new Product();
        protected IUserSession _userSession;
        protected void Page_Load(object sender, EventArgs e)
        {
            _userSession = ObjectFactory.GetInstance<IUserSession>();
            HandleLanguage();
            products = LoadDefault();
        }
        public void HandleLanguage()
        {
            bool isEng = IsEnglish();
            lblPhoto.Text = isEng ? Resources.English.photo : Resources.Poland.photo;
            lblPrice.Text = isEng ? Resources.English.Price : Resources.Poland.Price;
            lblName.Text = isEng ? Resources.English.NameProduct : Resources.Poland.NameProduct;
            lblDescription.Text = isEng ? Resources.English.description : Resources.Poland.description;
            Button1.Text = isEng ? Resources.English.AddYourCart : Resources.Poland.AddYourCart;
        }
        public Product LoadDefault()
        {
            int annID = GetAnnID();
            Product ann = new Product();
            if (annID > 0)
            {
                 ann = Product.Single(annID);
            }
            return ann;
        }
        public string GetObjectByLanguage(string ob)
        {
            int lg = (int)Languages.English;
            string lang = QueryHelper.GetQueryString(Request, "lang");
            switch (lang)
            {
                case "po":
                    lg = (int)Languages.Poland;
                    break;
                case "en":
                default:
                    lg = (int)Languages.English;
                    break;
            }
            return Utils.GetStringInString(ob.ToString(), Utils.flychips, lg);
        }
        public int GetAnnID()
        {
            int id = LibConvert.ConvertToInt(QueryHelper.GetQueryString(Request, "value"), 0);
            if (id != 0) return id;
            else
                Response.Redirect("Default.aspx");
            return 0;
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
        public bool IsExistProductInCart(YourCarts item)
        {
            List<YourCarts> rs = _userSession.ListCart;
            foreach (YourCarts i in rs)
                if (i.Item.ProductID == item.Item.ProductID)
                {
                    i.Soluong++;
                    _userSession.ListCart = rs;
                    return true;
                }
            return false;
        }
        public List<YourCarts> listAdd = new List<YourCarts>();
        public void AddToCart(YourCarts item)
        {
            if (_userSession.ListCart == null) _userSession.ListCart = new List<YourCarts>();
            if(!IsExistProductInCart(item))
                _userSession.ListCart.Add(item);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Product i = LoadDefault();
            int id = GetAnnID();
            YourCarts pr = new YourCarts(i,1);
            AddToCart(pr);
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
}