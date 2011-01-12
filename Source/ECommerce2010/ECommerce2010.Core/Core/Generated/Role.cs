using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace ECommerce2010.Core
{
    [SubSonicTableNameOverride("Roles")]
    public partial class Role : EntityBase<Role>
    {
        #region Properties


        public override object Id
        {

            get { return RoleID; }
            set { RoleID = (int)value; }
        }

        [SubSonicPrimaryKey]
        public int RoleID { get; set; }
        public string Name { get; set; }

        #endregion

        public Role()
        {

        }

        public Role(object id)
        {
            if (id != null)
            {
                Role entity = Single(id);
                if (entity != null)
                    entity.CopyTo<Role>(this);
                else
                    this.RoleID = 0;
            }
        }

        public bool Save()
        {
            bool rs = false;
            if (RoleID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }
    }
}
