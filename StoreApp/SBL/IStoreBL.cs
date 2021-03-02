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
        void addCustomer(Customers newCustomer);
        void addVisistedStore(LocationVisited store);
        void addNewOrder();
        void addOrderItem(OrderItem newOrderItem);
        void addTrackOrderItem(TrackOrder newTrackOrder);
        void addProductToInventory(StoreInventory storeInventory);
        void addProductToDb(Product product);
        void getStoreInventory(Store store);
        void getCustomerByName(String customerName);
        void getAllProducts();
        Store getStoreByName(String storeName);
        Customers getCustomerByEmail(String email);
        Product getProductByName(String productName);
        Orders getMostRecentOrder();
        OrderItem getMostRecentOrderItem();
        Manager getManagerByFirstName(String managerName);
    }
}