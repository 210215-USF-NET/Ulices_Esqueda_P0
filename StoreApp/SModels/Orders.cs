using System;
using System.Collections.Generic;

namespace SModels
{
    public class Orders
    {
        public int OrderNum { get; set; }

        public List<Product> ListOfProducts { get; set; }
    }
}