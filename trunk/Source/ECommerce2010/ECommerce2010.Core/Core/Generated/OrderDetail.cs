using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.BaseClasses;
using SubSonic.Extensions;
using SubSonic.SqlGeneration.Schema;

namespace ECommerce2010.Core
{
    [SubSonicTableNameOverride("OrderDetails")]
    public partial class OrderDetail : EntityBase<OrderDetail>
    {
        #region Properties


        public override object Id
        {

            get { return OrderDetailID; }
            set { OrderDetailID = (int)value; }
        }

        [SubSonicPrimaryKey]
        public int OrderDetailID { get; set; }
        public decimal UnitPrice { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Qualitity { get; set; }
        #endregion

        public OrderDetail()
        {

        }

        public OrderDetail(object id)
        {
            if (id != null)
            {
                OrderDetail entity = Single(id);
                if (entity != null)
                    entity.CopyTo<OrderDetail>(this);
                else
                    this.OrderDetailID = 0;
            }
        }

        public bool Save()
        {
            bool rs = false;
            if (OrderDetailID > 0)
                rs = Update(this) > 0;
            else
                rs = Add(this) != null;
            return rs;
        }
    }
}
