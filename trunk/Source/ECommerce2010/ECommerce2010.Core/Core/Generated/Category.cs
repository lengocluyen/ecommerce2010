using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace ECommerce2010.Core
{
    [SubSonicTableNameOverride("Categories")]
    public partial class Category : EntityBase<Category>
    {
        #region Properties


        public override object Id
        {

            get { return CategoryID; }
            set { CategoryID = (int)value; }
        }

        [SubSonicPrimaryKey]
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public int OrderNo { get; set; }
        public int ParentID { get; set; }
        public bool IsActive { get; set; }
        #endregion

        public Category()
        {

        }

        public Category(object id)
        {
            if (id != null)
            {
                Category entity = Single(id);
                if (entity != null)
                    entity.CopyTo<Category>(this);
                else
                    this.CategoryID = 0;
            }
        }

        public bool Save()
        {
            bool rs = false;
            if (CategoryID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }
    }
}
