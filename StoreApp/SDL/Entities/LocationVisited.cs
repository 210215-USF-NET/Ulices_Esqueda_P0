﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SDL.Entities
{
    public partial class LocationVisited
    {
        public int LocationVisitedId { get; set; }
        public int? CustomerId { get; set; }
        public int? StoreId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Store Store { get; set; }
    }
}
