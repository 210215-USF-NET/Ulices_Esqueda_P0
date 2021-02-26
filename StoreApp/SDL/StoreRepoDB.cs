using System.Collections.Generic;
using Model = SModels;
using Entity = SDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SDL
{
    public class StoreRepoDB : IStoreRepo
    {
        private Entity.p0dbContext _context;
        public StoreRepoDB(Entity.p0dbContext context){
            _context = context;
        }
        public List<Model.Product> getInventory()
        {
            throw new System.NotImplementedException();
        }

        public List<Model.Location> getLocations()
        {
            throw new System.NotImplementedException();
        }

        public List<Model.Orders> getOrders()
        {
            throw new System.NotImplementedException();
        }

        public Model.Orders PlaceOrder(Model.Orders newOrder)
        {
            throw new System.NotImplementedException();
        }
    }
}