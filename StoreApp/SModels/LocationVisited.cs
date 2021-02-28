using System;

namespace SModels
{
    public class LocationVisited
    {
        public int LocationVisitedID { get; set; }
        public Customers Customer { get; set; }
        public Store Store { get; set; }
    }
}