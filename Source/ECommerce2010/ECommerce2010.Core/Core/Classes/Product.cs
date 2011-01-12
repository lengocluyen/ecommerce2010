using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;
using SubSonic.BaseClasses;
using SubSonic.SqlGeneration.Schema;
using SubSonic.Schema;

namespace ECommerce2010.Core
{
    public partial class Product
    {
        // all method is static 
        public static PagedList<Product> GetRolePaging(int page, int pagesize)
        {
            PagedList<Product> list = Product.GetPaged(page -1, pagesize);
            return list;
        }
    }
}


