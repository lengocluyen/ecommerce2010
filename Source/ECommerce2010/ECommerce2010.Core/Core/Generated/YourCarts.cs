using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce2010.Core
{
    public class YourCarts
    {
        Product item;

        public Product Item
        {
            get { return item; }
            set { item = value; }
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
            item = i;
            Soluong=sl;
        }
    }
}
