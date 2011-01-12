using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace ECommerce2010.Core
{
    [SubSonicTableNameOverride("Users")]
    public partial class User : EntityBase<User>
    {
        #region Properties


        public override object Id
        {

            get { return UserID; }
            set { UserID = (int)value; }
        }


        [SubSonicPrimaryKey]
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool Sex { get; set; }
        public string Country { get; set; }
        public int RoleID { get; set; }
        public DateTime Created { get; set; }
        public DateTime Birthday { get; set; }
        public bool IsEnabled { get; set; }
        #endregion

        public User()
        {

        }

        public User(object id)
        {
            if (id != null)
            {
                User entity = Single(id);
                if (entity != null)
                    entity.CopyTo<User>(this);
                else
                    this.UserID = 0;
            }
        }

        public bool Save()
        {
            bool rs = false;
            if (UserID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }
    }
}
