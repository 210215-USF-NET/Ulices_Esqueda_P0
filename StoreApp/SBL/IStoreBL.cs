using System;
using System.Collections.Generic;
using SModels;

namespace SBL
{
    public interface IStoreBL
    {
        List<Product> getInventory();
        List<Orders> getOrders();
        List<LocationVisited> getLocations();
        void PlaceOrder(Orders newOrder);
    }
}