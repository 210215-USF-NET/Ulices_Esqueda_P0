using System;
using System.Collections.Generic;
using SModels;
using SDL;


namespace SBL
{
    public class StoreBL : IStoreBL
    {
        private IStoreRepo _repo;
        public StoreBL(IStoreRepo repo){
            _repo = repo;
        }

        public List<Product> getInventory(Store store){
            return _repo.getInventory(store);
        }
        public void getOrderHistory(Customers customer){
            _repo.getOrderHistory(customer);
        }

        public void getLocationHistory(Customers customer){
            _repo.getLocationHistory(customer);
        }

        public void getAllStoreNames(){
            _repo.getAllStoreNames();
        }

        public Store getStoreByName(String storeName){
            return _repo.getStoreByName(storeName);
        }

        public Customers getCustomerByEmail(String email){
            return _repo.getCustomerByEmail(email);
        }

        public void addCustomer(Customers newCustomer)
        {
            _repo.addCustomer(newCustomer);
        }

        public void addVisistedStore(LocationVisited store)
        {
            _repo.addVisistedStore(store);
        }

        public Product getProductByName(string productName)
        {
            return _repo.getProductByName(productName);
        }

        public void addNewOrder()
        {
            _repo.addNewOrder();
        }

        public void addOrderItem(OrderItem newOrderItem)
        {
            _repo.addOrderItem(newOrderItem);
        }

        public void addTrackOrderItem(TrackOrder newTrackOrder)
        {
            _repo.addTrackOrderItem(newTrackOrder);
        }

        public Orders getMostRecentOrder()
        {
            return _repo.getMostRecentOrder();
        }

        public OrderItem getMostRecentOrderItem()
        {
            return _repo.getMostRecentOrderItem();
        }

        public void getStoreInventory(Store store)
        {
            _repo.getStoreInventory(store);
        }

        public Manager getManagerByFirstName(String managerName)
        {
            return _repo.getManagerByFirstName(managerName);
        }

        public void getCustomerByName(string customerName)
        {
            _repo.getCustomerByName(customerName);
        }

        public void getAllProducts()
        {
            _repo.getAllProducts();
        }

        public void addProductToInventory(StoreInventory storeInventory)
        {
            _repo.addProductToInventory(storeInventory);
        }

        public void addProductToDb(Product product)
        {
            _repo.addProductToDb(product);
        }
    }
}