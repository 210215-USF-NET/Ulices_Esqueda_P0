using SDL.Entities;
using SModels;
using System.Collections.Generic;

namespace SDL
{
    public class StoreMapper : IMapper
    {
        public Customers ParseCustomer(Customer customer)
        {
            return new Customers{
                CustomerID = customer.CustomerId,
                CustomerFirstName = customer.CustomerFirstName,
                CustomerLastName = customer.CustomerLastName,
                CustomerPhoneNumber = customer.CustomerPhoneNumber,
                Email = customer.CustomerEmail
            };
        }

        public Customer ParseCustomer(Customers customer)
        {
            return new Customer{
                CustomerId = customer.CustomerID,
                CustomerFirstName = customer.CustomerFirstName,
                CustomerLastName = customer.CustomerLastName,
                CustomerEmail = customer.Email,
                CustomerPhoneNumber = customer.CustomerPhoneNumber
            };
        }

        public SModels.LocationVisited ParseLocation(Entities.LocationVisited location)
        {
            return new SModels.LocationVisited{
                LocationVisitedID = location.LocationVisitedId,
                Customer = ParseCustomer(location.Customer),
                Store = ParseStore(location.Store)
            };
        }

        public Entities.LocationVisited ParseLocation(SModels.LocationVisited location)
        {
            return new Entities.LocationVisited{
                LocationVisitedId = location.LocationVisitedID,
                CustomerId = location.Customer.CustomerID,
                StoreId = location.Store.StoreID
            };
        }

        public SModels.Manager ParseManager(Entities.Manager manager)
        {
            return new SModels.Manager{
                ManagerID = manager.ManagerId,
                ManagerFirstName = manager.ManagerFirstName,
                ManagerLastName = manager.ManagerLastName
            };
        }

        public Entities.Manager ParseManager(SModels.Manager manager)
        {
            return new Entities.Manager{
                ManagerId = manager.ManagerID,
                ManagerFirstName = manager.ManagerFirstName,
                ManagerLastName = manager.ManagerLastName
            };
        }

        public Orders ParseOrder(Order order)
        {
            return new Orders {
                OrderID = order.OrderId,
                OrderDate = order.OrderDate,
                OrderTotal = order.OrderTotal
            };
        }

        public Order ParseOrder(Orders order)
        {
            return new Order{
                OrderId = order.OrderID,
                OrderDate = order.OrderDate,
                OrderTotal = order.OrderTotal
            };
        }

        public SModels.OrderItem ParseOrderItem(Entities.OrderItem orderItem)
        {
            return new SModels.OrderItem{
                OrderItemID = orderItem.OrderItemId,
                Product = ParseOrderItem(orderItem).Product,
                ProductQuantity = orderItem.ProductQuantity
            };
        }

        public Entities.OrderItem ParseOrderItem(SModels.OrderItem orderItem)
        {
            return new Entities.OrderItem{
                OrderItemId = orderItem.OrderItemID,
                ProductId = orderItem.Product.ProductID,
                ProductQuantity = orderItem.ProductQuantity
            };
        }

        public SModels.Product ParseProduct(Entities.Product product)
        {
            return new SModels.Product {
                ProductID = product.ProductId,
                ProductName = product.ProductName,
                Price = product.ProductPrice
            };
        }

        public Entities.Product ParseProduct(SModels.Product product)
        {
            return new Entities.Product{
                ProductId = product.ProductID,
                ProductName = product.ProductName,
                ProductPrice = product.Price
            };
        }

        public SModels.Store ParseStore(Entities.Store store)
        {
            return new SModels.Store{
                StoreID = store.StoreId,
                StoreName = store.StoreName,
                StoreLocation = store.StoreLocation,
                //StoreManager = ParseManager(store.StoreManager)
            };
        }

        public Entities.Store ParseStore(SModels.Store store)
        {
            return new Entities.Store{
                StoreId = store.StoreID,
                StoreName = store.StoreName,
                StoreLocation = store.StoreLocation,
                //StoreManagerId = store.StoreManager.ManagerID
            };
        }

        public SModels.StoreInventory ParseStoreInventory(Entities.StoreInventory storeInventory)
        {
            return new SModels.StoreInventory{
                StoreInventoryID = storeInventory.StoreInventoryId,
                Store = ParseStore(storeInventory.Store),
                Product = ParseProduct(storeInventory.Product),
                InventoryQuantity = storeInventory.InventoryQuantity
            };
        }

        public Entities.StoreInventory ParseStoreInventory(SModels.StoreInventory storeInventory)
        {
            return new Entities.StoreInventory{
                StoreInventoryId = storeInventory.StoreInventoryID,
                StoreId = storeInventory.Store.StoreID,
                ProductId = storeInventory.Product.ProductID,
                InventoryQuantity = storeInventory.InventoryQuantity
            };
        }

        public SModels.TrackOrder ParseTrackOrder(Entities.TrackOrder trackOrder)
        {
            return new SModels.TrackOrder{
                TrackOrderID = trackOrder.TrackOrderId,
                Customer = ParseCustomer(trackOrder.Customer),
                Order = ParseOrder(trackOrder.Order),
                OrderItem = ParseOrderItem(trackOrder.OrderItem),
                Store = ParseStore(trackOrder.Store)
            };
        }

        public Entities.TrackOrder ParseTrackOrder(SModels.TrackOrder trackOrder)
        {
            return new Entities.TrackOrder {
                TrackOrderId = trackOrder.TrackOrderID,
                CustomerId = trackOrder.Customer.CustomerID,
                OrderId = trackOrder.Order.OrderID,
                OrderItemId = trackOrder.OrderItem.OrderItemID,
                StoreId = trackOrder.Store.StoreID
            };
        }
    }
}