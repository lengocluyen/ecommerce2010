using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;
using SubSonic.BaseClasses;
using SubSonic.SqlGeneration.Schema;
using SubSonic.Schema;

namespace ECommerce2010.Core
{
    public partial class OrderDetail
    {
        // all method is static 
        public static PagedList<OrderDetail> GetRolePaging(int page, int pagesize)
        {
            PagedList<OrderDetail> list = OrderDetail.GetPaged(page -1, pagesize);
            return list;
        }
    }
}


