using System;
using System.Collections.Generic;

#nullable disable

namespace SDL.Entities
{
    public partial class Order
    {
        public Order()
        {
            TrackOrders = new HashSet<TrackOrder>();
        }

        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderTotal { get; set; }

        public virtual ICollection<TrackOrder> TrackOrders { get; set; }
    }
}
