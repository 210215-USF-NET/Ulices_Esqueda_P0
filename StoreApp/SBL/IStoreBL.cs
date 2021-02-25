using System;
using System.Collections.Generic;
using SModels;

namespace SBL
{
    public interface IStoreBL
    {
        List<Product> getInventory();
        List<Orders> getOrders();
        List<Location> getLocations();
        void PlaceOrder(Orders newOrder);
    }
}