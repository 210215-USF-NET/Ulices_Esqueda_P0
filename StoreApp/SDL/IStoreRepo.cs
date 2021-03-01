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
        Product getProductByName(String productName);
        Customers getCustomerByEmail(String email);
        Customers addCustomer(Customers newCustomer);
        Orders getNewOrder();
        OrderItem addOrderItem(OrderItem newOrderItem);

        void addTrackOrderItem(TrackOrder newTrackOrder);
    }
}