using System;
using System.Collections.Generic;
using Revature.Ulices_Esqueda_P0.StoreApp.SModels;


namespace SBL
{
    public interface IStoreBL
    {
        List<Product> getInventory();
        List<Orders> getOrders();
        void PlaceOrder(Orders newOrder);
    }
}