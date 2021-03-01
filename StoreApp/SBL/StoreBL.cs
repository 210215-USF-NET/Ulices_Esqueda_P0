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

        public Customers addCustomer(Customers newCustomer)
        {
            return _repo.addCustomer(newCustomer);
        }

        public void addVisistedStore(LocationVisited store)
        {
            _repo.addVisistedStore(store);
        }

        public Product getProductByName(string productName)
        {
            return _repo.getProductByName(productName);
        }

        public Orders addNewOrder()
        {
            return _repo.getNewOrder();
        }

        public OrderItem addOrderItem(OrderItem newOrderItem)
        {
            return _repo.addOrderItem(newOrderItem);
        }

        public void addTrackOrderItem(TrackOrder newTrackOrder)
        {
            _repo.addTrackOrderItem(newTrackOrder);
        }
    }
}