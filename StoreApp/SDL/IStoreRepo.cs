using System;
using System.Collections.Generic;
using SModels;

namespace SDL
{
    public interface IStoreRepo
    {
        List<Products> getInventory();
        List<Orders> getOrders();
        Orders PlaceOrder(Orders newOrder);
    }
}