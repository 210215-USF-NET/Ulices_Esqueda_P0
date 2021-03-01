using System;
using System.Collections.Generic;

#nullable disable

namespace SDL.Entities
{
    public partial class OrderItem
    {
        public OrderItem()
        {
            TrackOrders = new HashSet<TrackOrder>();
        }

        public int OrderItemId { get; set; }
        public int? ProductId { get; set; }
        public int ProductQuantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual ICollection<TrackOrder> TrackOrders { get; set; }
    }
}
