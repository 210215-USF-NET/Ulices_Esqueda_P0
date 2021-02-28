using System;
using System.Collections.Generic;
using SModels;

namespace SBL
{
    public interface IStoreBL
    {
        List<Product> getInventory(Store store);
        void getOrderHistory(Customers customer);
        void getLocationHistory(Customers customer);
        void PlaceOrder(Orders newOrder);
        Customers getCustomerByEmail(String email);
        Customers addCustomer(Customers newCustomer);
    }
}