using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce2010.Core
{
    public class YourCarts
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
        public YourCarts()
        {

        }
        public YourCarts(Product i, int sl)
        {
            Item1 = i;
            Soluong=sl;
        }
    }
}
