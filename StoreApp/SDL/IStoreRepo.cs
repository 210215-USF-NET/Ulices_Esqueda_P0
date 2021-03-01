using System;
using System.Collections.Generic;
using SModels;

namespace SDL
{
    public interface IStoreRepo
    {
        List<Product> getInventory(Store store);
        void getOrderHistory(Customers customer);
        void getLocationHistory(Customers customer);
        void getAllStoreNames();
        void addVisistedStore(LocationVisited store);
        Store getStoreByName(String storeName);
        Orders PlaceOrder(Orders newOrder);
        Customers getCustomerByEmail(String email);
        Customers addCustomer(Customers newCustomer);
    }
}