using System;
using System.Collections.Generic;
using SModels;

namespace SDL
{
    public interface IStoreRepo
    {
        void getOrderHistory(Customers customer);
        void getOrderHistory(Customers customer, int number);
        void getOrderHistory(Store store, int number);
        void getOrderHistory(Store store);
        void getLocationHistory(Customers customer);
        void getAllStoreNames();
        void addVisistedStore(LocationVisited store);
        void addCustomer(Customers newCustomer);
        void addNewOrder();
        void addOrderItem(OrderItem newOrderItem);
        void addTrackOrderItem(TrackOrder newTrackOrder);
        void addProductToInventory(StoreInventory storeInventory);
        void addProductToDb(Product product);
        void getStoreInventory(Store store);
        void getCustomerByName(String customerName);
        void getAllProducts();
        void getAllStoreNames(Manager manager);
        void updateOrderTotal(Orders total);
        void updateStoreInventory(StoreInventory storeInventory);
        Store getStoreByName(String storeName);
        Product getProductByName(String productName);
        Product getStoreProductByName(String productName, Store store);
        Customers getCustomerByEmail(String email);
        Orders getMostRecentOrder();
        OrderItem getMostRecentOrderItem();
        Manager getManagerByFirstName(String managerName);
        bool checkStoreInventory(Store store);
        int getInventoryQuantity(Product product, Store store);
        StoreInventory getInventoryItem(Product product, Store store);
    }
}