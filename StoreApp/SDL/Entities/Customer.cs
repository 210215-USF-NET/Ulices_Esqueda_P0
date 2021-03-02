using System;
using System.Collections.Generic;

#nullable disable

namespace SDL.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            LocationVisiteds = new HashSet<LocationVisited>();
            TrackOrders = new HashSet<TrackOrder>();
        }

        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhoneNumber { get; set; }
        

        public virtual ICollection<LocationVisited> LocationVisiteds { get; set; }
        public virtual ICollection<TrackOrder> TrackOrders { get; set; }
    }
}
