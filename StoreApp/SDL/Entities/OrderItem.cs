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
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }

        public virtual ICollection<TrackOrder> TrackOrders { get; set; }
    }
}
