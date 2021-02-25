using System;
using System.Collections.Generic;
using SModels;

namespace SDL
{
    public interface IStoreRepo
    {
        List<Product> getInventory();
        List<Orders> getOrders();
        List<Location> getLocations();
        Orders PlaceOrder(Orders newOrder);
    }
}