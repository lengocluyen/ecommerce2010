using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace ECommerce2010.Core
{
    [SubSonicTableNameOverride("Contacts")]
    public partial class Contact : EntityBase<Contact>
    {
        #region Properties


        public override object Id
        {

            get { return ContactID; }
            set { ContactID = (int)value; }
        }

        [SubSonicPrimaryKey]
        public int ContactID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public bool Active { get; set; }
        #endregion

        public Contact()
        {

        }

        public Contact(object id)
        {
            if (id != null)
            {
                Contact entity = Single(id);
                if (entity != null)
                    entity.CopyTo<Contact>(this);
                else
                    this.ContactID = 0;
            }
        }

        public bool Save()
        {
            bool rs = false;
            if (ContactID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }
    }
}
