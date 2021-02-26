using System;
using System.Collections.Generic;

#nullable disable

namespace SDL.Entities
{
    public partial class Manager
    {
        public Manager()
        {
            Stores = new HashSet<Store>();
        }

        public int ManagerId { get; set; }
        public string ManagerFirstName { get; set; }
        public string ManagerLastName { get; set; }

        public virtual ICollection<Store> Stores { get; set; }
    }
}
