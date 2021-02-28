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

        public void PlaceOrder(Orders newOrder){
            _repo.PlaceOrder(newOrder);
        }

        public Customers getCustomerByEmail(String email){
            return _repo.getCustomerByEmail(email);
        }

        public Customers addCustomer(Customers newCustomer)
        {
            return _repo.addCustomer(newCustomer);
        }
    }
}