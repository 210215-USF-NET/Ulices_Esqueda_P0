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
        void getAllStoreNames();
        Store getStoreByName(String storeName);
        Customers getCustomerByEmail(String email);
        Product getProductByName(String productName);
        Customers addCustomer(Customers newCustomer);
        void addVisistedStore(LocationVisited store);
        Orders addNewOrder();
        OrderItem addOrderItem(OrderItem newOrderItem);
        void addTrackOrderItem(TrackOrder newTrackOrder);
    }
}