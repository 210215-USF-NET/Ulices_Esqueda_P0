using System;
using System.Collections.Generic;
using Revature.Ulices_Esqueda_P0.StoreApp.SModels;

namespace SDL
{
    public interface IStoreRepo
    {
        List<Product> getInventory();
        List<Orders> getOrders();
        Orders PlaceOrder(Orders newOrder);
    }
}