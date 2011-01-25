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
    public partial class InfoCart : System.Web.UI.UserControl
    {
       public int countProduct = 0;
       public decimal total = 0;
        IUserSession _userSession;
        protected void Page_Load(object sender, EventArgs e)
        {
            _userSession = ObjectFactory.GetInstance<IUserSession>();
            HandleLanguage();
            if (_userSession.ListCart == null) return;
            foreach (YourCarts i in _userSession.ListCart)
            {
                total += i.Soluong * i.Item.Price;
                countProduct++;
            }

        }
        public void HandleLanguage()
        {
            bool isEng = IsEnglish();
            lbldetailCart.Text = isEng ? Resources.English.DetailCart : Resources.Poland.DetailCart;
            lblTotal.Text = isEng ? Resources.English.TotalMoney : Resources.Poland.TotalMoney;
            lblTotalProduct.Text = isEng ? Resources.English.TotalProduction : Resources.Poland.TotalProduction;
            tLeftTitle1.InnerText = isEng ? Resources.English.yourcart : Resources.Poland.yourcart;
            
        }
        public bool IsEnglish()
        {
            string lang = QueryHelper.GetQueryString(Request, "lang");

            switch (lang)
            {
                case "po":
                    adetailCart.Attributes.Add("href", "../../Default.aspx?lang=po&do=yourcart");
                    return false;
                case "en":
                default:
                    adetailCart.Attributes.Add("href", "../../Default.aspx?lang=en&do=yourcart");
                    return true;
            }
        }
    }
}