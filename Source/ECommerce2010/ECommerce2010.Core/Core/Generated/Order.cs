using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace ECommerce2010.Core
{
    [SubSonicTableNameOverride("Orders")]
    public partial class Order : EntityBase<Order>
    {
        #region Properties


        public override object Id
        {

            get { return OrderID; }
            set { OrderID = (int)value; }
        }

        [SubSonicPrimaryKey]
        public int OrderID { get; set; }
        public DateTime OrderDay { get; set; }
        public int Total { get; set; }
        public int UserID { get; set; }
        #endregion

        public Order()
        {

        }

        public Order(object id)
        {
            if (id != null)
            {
                Order entity = Single(id);
                if (entity != null)
                    entity.CopyTo<Order>(this);
                else
                    this.OrderID = 0;
            }
        }

        public bool Save()
        {
            bool rs = false;
            if (OrderID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }
    }
}
