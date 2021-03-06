using System;
using System.Collections.Generic;
using SModels;

namespace SBL
{
    public interface IStoreBL
    {
        void getOrderHistory(Customers customer);
        void getOrderHistory(Customers customer, int number);
        void getOrderHistory(Store store, int number);
        void getOrderHistory(Store store);
        void getLocationHistory(Customers customer);
        void getAllStoreNames();
        void getAllStoreNames(Manager manager);
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
        void updateOrderTotal(Orders total);
        void updateStoreInventory(StoreInventory storeInventory);
        StoreInventory getInventoryItem(Product product, Store store);
        Store getStoreByName(String storeName);
        Customers getCustomerByEmail(String email);
        Product getProductByName(String productName);
        Product getStoreProductByName(String productName, Store store);
        Orders getMostRecentOrder();
        OrderItem getMostRecentOrderItem();
        Manager getManagerByFirstName(String managerName);
        bool checkStoreInventory(Store store);
        int getInventoryQuantity(Product product, Store store);
    }
}