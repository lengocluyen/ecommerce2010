using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace ECommerce2010.Core
{
    [SubSonicTableNameOverride("Manufactories")]
    public partial class Manufactory : EntityBase<Manufactory>
    {
        #region Properties


        public override object Id
        {

            get { return ManufactoryID; }
            set { ManufactoryID = (int)value; }
        }

        [SubSonicPrimaryKey]
        public int ManufactoryID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        #endregion

        public Manufactory()
        {

        }

        public Manufactory(object id)
        {
            if (id != null)
            {
                Manufactory entity = Single(id);
                if (entity != null)
                    entity.CopyTo<Manufactory>(this);
                else
                    this.ManufactoryID = 0;
            }
        }

        public bool Save()
        {
            bool rs = false;
            if (ManufactoryID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }
    }
}
