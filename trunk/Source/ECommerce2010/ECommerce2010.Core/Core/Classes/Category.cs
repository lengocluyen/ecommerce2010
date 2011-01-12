using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;
using SubSonic.BaseClasses;
using SubSonic.SqlGeneration.Schema;
using SubSonic.Schema;

namespace ECommerce2010.Core
{
    public partial class Category
    {
        // all method is static 
        public static PagedList<Category> GetCategoryPaging(int page, int pagesize)
        {
            return Category.GetPaged(page - 1, pagesize);
        }

        /// <summary>
        /// Lấy Category mức 1
        /// </summary>
        /// <returns></returns>
        public static List<Category> GetParentCategory()
        {
            return Category.Find(c => c.ParentID == 0);
        }

        /// <summary>
        /// Lấy Category mức 2
        /// </summary>
        /// <param name="idParent"></param>
        /// <returns></returns>
        public static List<Category> GetCategoryByParentId(int idParent)
        {
            return Category.Find(c => c.ParentID == idParent);
        }
    }
}


