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

        public List<Product> getInventory(){
            return _repo.getInventory();
        }
        public List<Orders> getOrders(){
            return _repo.getOrders();
        }

        public List<Location> getLocations(){
            return _repo.getLocations();
        }

        public void PlaceOrder(Orders newOrder){
            _repo.PlaceOrder(newOrder);
        }

    }
}