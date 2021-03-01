using System.Collections.Generic;
using Model = SModels;
using Entity = SDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SModels;
using System;

namespace SDL
{
    public class StoreRepoDB : IStoreRepo
    {
        private Entity.p0dbContext _context;
        private IMapper _mapper;
        public StoreRepoDB(Entity.p0dbContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }
        public List<Model.Product> getInventory(Model.Store store)
        {
            throw new System.NotImplementedException();
        }

        public void getLocationHistory(Model.Customers customer)
        {
            var queryCustomerLocationHistory = (
                from loc in _context.LocationVisiteds
                join store in _context.Stores on loc.StoreId equals store.StoreId
                where loc.CustomerId == customer.CustomerID
                select new {store.StoreLocation}
            );
            if(!queryCustomerLocationHistory.Any()){
                Console.WriteLine("Seems like you haven't visited any stores.");
                Console.WriteLine("Please visit a shop and see what they have to offer!");
            }
            else {
                foreach (var item in queryCustomerLocationHistory)
                {
                    Console.WriteLine($"You've been to: {item.StoreLocation}");
                }
            }
        }

        public void getAllStoreNames(){
            var queryAllStoreLocations = (
                from store in _context.Stores
                select store
            );
            foreach (var item in queryAllStoreLocations)
            {
                Console.WriteLine(item.StoreName);
            }
        }

        public void getOrderHistory(Model.Customers customer)
        {
            var queryCustomerOrderHistory = (
                from track in _context.TrackOrders
                join order in _context.Orders on track.OrderId equals order.OrderId
                where track.CustomerId == customer.CustomerID
                select new {track.OrderId, order.OrderDate, order.OrderTotal}
            );
            if (!queryCustomerOrderHistory.Any()){
                Console.WriteLine("Seems like you haven't made an order");
                Console.WriteLine("Please visit a shop to make your first order.");
            }
            else{
                foreach (var item in queryCustomerOrderHistory)
                {
                    Console.WriteLine($"Order {item.OrderId}, OrderDate: {item.OrderDate}, Order Total: {item.OrderTotal}");
                }
            }
        }

        public Model.Orders PlaceOrder(Model.Orders newOrder)
        {
            throw new System.NotImplementedException();
        }

        public Customers getCustomerByEmail(string email){
            var queryCustomersByEmail = (from cust in _context.Customers
                                        where cust.CustomerEmail == email
                                        select cust).ToList().FirstOrDefault();
            if (queryCustomersByEmail == null){
                return null;
            }
            return _mapper.ParseCustomer(queryCustomersByEmail);
        }

        public Customers addCustomer(Customers newCustomer)
        {
            _context.Customers.Add(_mapper.ParseCustomer(newCustomer));
            _context.SaveChanges();
            return newCustomer;
        }

        public Store getStoreByName(string storeName)
        {
            var queryStoreByName = (
                from store in _context.Stores
                where store.StoreName == storeName
                select store).ToList().FirstOrDefault();
            if (queryStoreByName == null){
                return null;
            }
            return _mapper.ParseStore(queryStoreByName);
        }

        public void addVisistedStore(LocationVisited location)
        {
            _context.LocationVisiteds.Add(_mapper.ParseLocation(location));
            _context.SaveChanges();
        }
    }
}