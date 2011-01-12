using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;
using SubSonic.BaseClasses;
using SubSonic.SqlGeneration.Schema;
using SubSonic.Schema;

namespace ECommerce2010.Core
{
    public partial class User
    {
        // all method is static 
        public static PagedList<User> GetUserPaging(int page, int pagesize)
        {
            return User.GetPaged(page-1, pagesize);
        }
    }
}


