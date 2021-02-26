using System;
using System.Collections.Generic;

#nullable disable

namespace SDL.Entities
{
    public partial class StoreInventory
    {
        public int StoreInventoryId { get; set; }
        public int? StoreId { get; set; }
        public int? ProductId { get; set; }
        public int InventoryQuantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
    }
}
