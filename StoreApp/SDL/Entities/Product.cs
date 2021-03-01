using System;
using System.Collections.Generic;

#nullable disable

namespace SDL.Entities
{
    public partial class Product
    {
        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
            StoreInventories = new HashSet<StoreInventory>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<StoreInventory> StoreInventories { get; set; }
    }
}
