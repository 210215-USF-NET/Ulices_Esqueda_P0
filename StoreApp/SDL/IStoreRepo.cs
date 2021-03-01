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
        void addCustomer(Customers newCustomer);
        void addNewOrder();
        void addOrderItem(OrderItem newOrderItem);
        void addTrackOrderItem(TrackOrder newTrackOrder);
        void getStoreInventory(Store store);
        Store getStoreByName(String storeName);
        Product getProductByName(String productName);
        Customers getCustomerByEmail(String email);
        Orders getMostRecentOrder();
        OrderItem getMostRecentOrderItem();
        Manager getManagerByFirstName(String managerName);
    }
}