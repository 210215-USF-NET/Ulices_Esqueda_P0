using Model = SModels;
using Entity = SDL.Entities;

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
    }
}