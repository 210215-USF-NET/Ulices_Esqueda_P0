using System;
using System.Collections.Generic;
using SModels;

namespace SDL
{
    public interface IStoreRepo
    {
        List<Product> getInventory(Store store);
        List<Orders> getOrders(Customers customer);
        List<LocationVisited> getLocations(Customers customer);
        Orders PlaceOrder(Orders newOrder);
    }
}