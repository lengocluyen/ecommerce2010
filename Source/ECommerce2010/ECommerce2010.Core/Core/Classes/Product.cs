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
        public static PagedList<Product> GetProductPaging(string category, int page, int pagesize)
        {
            page--;
            PagedList<Product> list;
            int categoryID = LibConvert.ConvertToInt(category,0);
            if (categoryID != 0)
            {
                var query = All().Where(p => p.CategoryID == categoryID);
                query = query.OrderByDescending(p => p.CreateDate);
                list = new PagedList<Product>(query,page,pagesize) ;
            }
            else
                list = Product.GetPaged(page, pagesize, "CreateDate DESC");
            return list;
        }
    }
}


