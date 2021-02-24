using System;

namespace Revature.Ulices_Esqueda_P0.StoreApp.SBL
{
    public class IStoreBL
    {
        List<Products> getInventory();
        List<Orders> getOrders();
        void PlaceOrder(Orders newOrder);
    }
}