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
        public List<Orders> getOrders(Customers customer){
            return _repo.getOrders(customer);
        }

        public List<LocationVisited> getLocations(Customers customer){
            return _repo.getLocations(customer);
        }

        public void PlaceOrder(Orders newOrder){
            _repo.PlaceOrder(newOrder);
        }

        public Customers getCustomerByEmail(String email){
            return _repo.getCustomerByEmail(email);
        }

    }
}