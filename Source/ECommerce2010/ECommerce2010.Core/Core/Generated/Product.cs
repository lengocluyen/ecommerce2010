using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace ECommerce2010.Core
{
    [SubSonicTableNameOverride("Products")]
    public partial class Product : EntityBase<Product>
    {
        #region Properties


        public override object Id
        {

            get { return ProductID; }
            set { ProductID = (int)value; }
        }

        [SubSonicPrimaryKey]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int Total { get; set; }
        public int CategoryID { get; set; }
        public int ManufactoryID { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        #endregion

        public Product()
        {

        }

        public Product(object id)
        {
            if (id != null)
            {
                Product entity = Single(id);
                if (entity != null)
                    entity.CopyTo<Product>(this);
                else
                    this.ProductID = 0;
            }
        }

        public bool Save()
        {
            bool rs = false;
            if (ProductID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }
    }
}
