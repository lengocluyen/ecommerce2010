using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;
using SubSonic.BaseClasses;
using SubSonic.SqlGeneration.Schema;
using SubSonic.Schema;

namespace ECommerce2010.Core
{
    public partial class Manufactory
    {
        // all method is static 
        public static PagedList<Manufactory> GetRolePaging(int page, int pagesize)
        {
            PagedList<Manufactory> list = Manufactory.GetPaged(page -1, pagesize);
            return list;
        }
    }
}


