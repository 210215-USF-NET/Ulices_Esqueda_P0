using System;
using System.Collections.Generic;
using SModels;

namespace SBL
{
    public interface IStoreBL
    {
        List<Product> getInventory(Store store);
        List<Orders> getOrders(Customers customer);
        List<LocationVisited> getLocations(Customers customer);
        void PlaceOrder(Orders newOrder);
        Customers getCustomerByEmail(String email);
    }
}