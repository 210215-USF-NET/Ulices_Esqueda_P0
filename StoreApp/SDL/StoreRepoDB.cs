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
                select new {store.StoreName, store.StoreLocation}
            ).Distinct();
            if(!queryCustomerLocationHistory.Any()){
                Console.WriteLine("Seems like you haven't visited any stores.");
                Console.WriteLine("Please visit a shop and see what they have to offer!");
            }
            else {
                foreach (var item in queryCustomerLocationHistory)
                {
                    Console.WriteLine("| {0, -20} | {1, 20} |", item.StoreName, item.StoreLocation);
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
                Console.WriteLine(String.Format("| {0, -25} |", item.StoreName));
            }
        }

        public void getOrderHistory(Model.Customers customer)
        {
            var queryCustomerOrderHistory = (
                from track in _context.TrackOrders
                join order in _context.Orders on track.OrderId equals order.OrderId
                where track.CustomerId == customer.CustomerID
                select new {track.OrderId, order.OrderDate, order.OrderTotal}
            ).Distinct();
            if (!queryCustomerOrderHistory.Any()){
                Console.WriteLine("Seems like you haven't made an order");
                Console.WriteLine("Please visit a shop to make your first order.");
            }
            else{
                foreach (var item in queryCustomerOrderHistory)
                {
                    Console.WriteLine(String.Format("| {0,-12} | {1, -22} | {2, 11} |", item.OrderId, item.OrderDate, item.OrderTotal));
                }
            }
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

        public void addCustomer(Customers newCustomer)
        {
            _context.Customers.Add(_mapper.ParseCustomer(newCustomer));
            _context.SaveChanges();
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

        public Product getProductByName(string productName)
        {
            var queryProductByName = (
                from product in _context.Products
                where product.ProductName == productName
                select product).ToList().FirstOrDefault();
            if (queryProductByName == null){
                return null;
            }
            return _mapper.ParseProduct(queryProductByName);
        }

        public void addNewOrder()
        {
            Orders order = new Orders();
            order.OrderDate = DateTime.Now;
            order.OrderTotal = 0;
            _context.Orders.Add(_mapper.ParseOrder(order));
            _context.SaveChanges();
        }

        public void addOrderItem(OrderItem newOrderItem)
        {
            _context.OrderItems.Add(_mapper.ParseOrderItem(newOrderItem));
            _context.SaveChanges();
        }

        public void addTrackOrderItem(TrackOrder newTrackOrder)
        {
            _context.TrackOrders.Add(_mapper.ParseTrackOrder(newTrackOrder));
            _context.SaveChanges();
        }
        public void addProductToInventory(StoreInventory newStoreInventory){
            try{
                _context.StoreInventories.Add(_mapper.ParseStoreInventory(newStoreInventory));
                _context.SaveChanges();
            } catch(Exception e){
                Console.WriteLine(e);
                //Do nothing and continue.
            }
        }
        public void addProductToDb(Product newProduct){
            _context.Products.Add(_mapper.ParseProduct(newProduct));
            _context.SaveChanges();
        }

        public Orders getMostRecentOrder()
        {
            var queryMostRecentOrder = (
                from order in _context.Orders
                select order
            ).ToList().LastOrDefault();
            if (queryMostRecentOrder == null){
                return null;
            }
            return _mapper.ParseOrder(queryMostRecentOrder);
        }

        public OrderItem getMostRecentOrderItem()
        {
            var queryMostRecentOrderItem = (
                from order in _context.OrderItems
                select order
            ).ToList().LastOrDefault();
            if (queryMostRecentOrderItem == null){
                return null;
            }
            return _mapper.ParseOrderItem(queryMostRecentOrderItem);
        }
        public void getStoreInventory(Store store){
            var queryInventory = (
                from inv in _context.StoreInventories
                join prod in _context.Products on inv.ProductId equals prod.ProductId
                select new {prod.ProductName, prod.ProductPrice, inv.InventoryQuantity}
            );
            if (!queryInventory.Any()){
                Console.WriteLine("Sorry about that but it seems like we ran out of products.");
                Console.WriteLine("Please come again later.");
            }
            else{
                foreach (var item in queryInventory)
                {
                    Console.WriteLine("-------------------------------------------------------------------------------------------------");
                    Console.WriteLine($"Product: {item.ProductName}, Price: {item.ProductPrice}, Quantity: {item.InventoryQuantity}");
                    Console.WriteLine("-------------------------------------------------------------------------------------------------");

                }
            }
        }
        public Manager getManagerByFirstName(String name){
            var queryManagerByFirstName = (
                from manager in _context.Managers
                where manager.ManagerFirstName == name
                select manager).ToList().FirstOrDefault();
            if (queryManagerByFirstName == null){
                return null;
            }
            return _mapper.ParseManager(queryManagerByFirstName);
        }

        public void getCustomerByName(string customerName)
        {
            var queryCustomersByName = (from cust in _context.Customers
                                        where cust.CustomerFirstName == customerName
                                        select cust).ToList().FirstOrDefault();

            if (queryCustomersByName == null){
                Console.WriteLine("There seems to be no customers with that name. Try another name.");
            }
            else{
                Console.WriteLine($"Customer name: { queryCustomersByName.CustomerFirstName } {queryCustomersByName.CustomerLastName}\nCustomer email: {queryCustomersByName.CustomerEmail}\nCustomer phone number: { queryCustomersByName.CustomerPhoneNumber }");

            }
        }

        public void getAllProducts()
        {
            var queryAllProducts = (
                from product in _context.Products
                select product
            );
            foreach (var item in queryAllProducts)
            {
                Console.WriteLine(String.Format("| {0, -64} |", item.ProductName));
            }
        }
    }
}