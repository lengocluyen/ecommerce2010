using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;
using SubSonic.BaseClasses;
using SubSonic.SqlGeneration.Schema;
using SubSonic.Schema;

namespace ECommerce2010.Core
{
    public partial class Contact
    {
        // all method is static 
        public static PagedList<Contact> GetContactPaging(int page, int pagesize)
        {
            return Contact.GetPaged(page - 1, pagesize);
        }

    }
}


