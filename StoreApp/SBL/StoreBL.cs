using System;
using System.Collections.Generic;
using SDL;
using SModels;


namespace SBL
{
    public class StoreBL : IStoreBL
    {
        private IStoreBL _repo;
        public StoreBL(IStoreRepo repo){
            _repo = (IStoreBL)repo;
        }

        public List<Product> getInventory(){
            return _repo.getInventory();
        }
        public List<Orders> getOrders(){
            return _repo.getOrders();
        }

        public void PlaceOrder(Orders newOrder){
            _repo.PlaceOrder(newOrder);
        }

    }
}