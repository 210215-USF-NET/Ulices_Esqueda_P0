using System;
using System.Collections.Generic;

#nullable disable

namespace SDL.Entities
{
    public partial class Product
    {
        public Product()
        {
            StoreInventories = new HashSet<StoreInventory>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }

        public virtual ICollection<StoreInventory> StoreInventories { get; set; }
    }
}
