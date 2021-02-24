using System;


namespace Revature.Ulices_Esqueda_P0.StoreApp.SDL
{
    public class IStoreRepo
    {
        List<Products> getInventory();
        List<Orders> getOrders();
        Orders PlaceOrder(Orders newOrder);
    }
}