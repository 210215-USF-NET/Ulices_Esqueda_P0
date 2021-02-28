using Model = SModels;
using Entity = SDL.Entities;
using System.Collections.Generic;

namespace SDL
{
    /// <summary>
    /// To parse entities from database from models used in BL and vice versa.
    /// </summary>
    public interface IMapper
    {
        Model.Customers ParseCustomer(Entity.Customer customer);

        Entity.Customer ParseCustomer(Model.Customers customer);

        Model.LocationVisited ParseLocation(Entity.LocationVisited location);

        Entity.LocationVisited ParseLocation(Model.LocationVisited location);

        Model.Manager ParseManager(Entity.Manager manager);

        Entity.Manager ParseManager(Model.Manager manager);

        Model.OrderItem ParseOrderItem(Entity.OrderItem orderItem);

        Entity.OrderItem ParseOrderItem(Model.OrderItem orderItem);

        Model.Orders ParseOrder(Entity.Order order);

        Entity.Order ParseOrder(Model.Orders order);

        Model.Product ParseProduct(Entity.Product product);

        Entity.Product ParseProduct(Model.Product product);

        Model.Store ParseStore(Entity.Store store);

        Entity.Store ParseStore(Model.Store store);

        Model.StoreInventory ParseStoreInventory(Entity.StoreInventory storeInventory);

        Entity.StoreInventory ParseStoreInventory(Model.StoreInventory storeInventory);

        Model.TrackOrder ParseTrackOrder(Entity.TrackOrder trackOrder);

        Entity.TrackOrder ParseTrackOrder(Model.TrackOrder trackOrder);

    }
}