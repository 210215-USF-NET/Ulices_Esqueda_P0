using System;
using System.Collections.Generic;

#nullable disable

namespace SDL.Entities
{
    public partial class TrackOrder
    {
        public int TrackOrderId { get; set; }
        public int? CustomerId { get; set; }
        public int? OrderId { get; set; }
        public int? OrderItemId { get; set; }
        public int? StoreId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Order Order { get; set; }
        public virtual OrderItem OrderItem { get; set; }
        public virtual Store Store { get; set; }
    }
}
