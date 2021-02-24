using System;

namespace SBL
{
    public interface IStoreBL
    {
        List<Product> getInventory();
        List<Orders> getOrders();
        void PlaceOrder(Orders newOrder);
    }
}