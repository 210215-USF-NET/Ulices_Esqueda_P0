using System;
using System.Collections.Generic;

#nullable disable

namespace SDL.Entities
{
    public partial class Store
    {
        public Store()
        {
            LocationVisiteds = new HashSet<LocationVisited>();
            StoreInventories = new HashSet<StoreInventory>();
            TrackOrders = new HashSet<TrackOrder>();
        }

        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreLocation { get; set; }
        public int? StoreManagerId { get; set; }

        public virtual Manager StoreManager { get; set; }
        public virtual ICollection<LocationVisited> LocationVisiteds { get; set; }
        public virtual ICollection<StoreInventory> StoreInventories { get; set; }
        public virtual ICollection<TrackOrder> TrackOrders { get; set; }
    }
}
