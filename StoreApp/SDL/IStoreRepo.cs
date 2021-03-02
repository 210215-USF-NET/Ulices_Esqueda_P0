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
        void addProductToInventory(StoreInventory storeInventory);
        void addProductToDb(Product product);
        void getStoreInventory(Store store);
        void getCustomerByName(String customerName);
        void getAllProducts();
        void getAllStoreNames(Manager manager);
        void updateOrderTotal(Orders total);
        Store getStoreByName(String storeName);
        Product getProductByName(String productName);
        Product getStoreProductByName(String productName, Store store);
        Customers getCustomerByEmail(String email);
        Orders getMostRecentOrder();
        OrderItem getMostRecentOrderItem();
        Manager getManagerByFirstName(String managerName);
        bool checkStoreInventory(Store store);
    }
}