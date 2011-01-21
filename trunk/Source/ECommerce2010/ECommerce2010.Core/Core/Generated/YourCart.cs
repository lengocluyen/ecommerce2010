using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce2010.Core.Core.Generated
{
    public class YourCart
    {
        Product Item;

        public Product Item1
        {
            get { return Item; }
            set { Item = value; }
        }
        int soluong = 0;

        public int Soluong
        {
            get { return soluong; }
            set { soluong = value; }
        }
        public YourCart()
        {

        }
        public YourCart(Product i, int sl)
        {
            Item1 = i;
            Soluong=sl;
        }
    }
}
