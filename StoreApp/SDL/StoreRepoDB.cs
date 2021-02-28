using System.Collections.Generic;
using Model = SModels;
using Entity = SDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SModels;

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

        public List<Model.LocationVisited> getLocations(Model.Customers customer)
        {
            throw new System.NotImplementedException();
        }

        public List<Model.Orders> getOrders(Model.Customers customer)
        {
            throw new System.NotImplementedException();
        }

        public Model.Orders PlaceOrder(Model.Orders newOrder)
        {
            throw new System.NotImplementedException();
        }

        public Customers getCustomerByEmail(string email){
            var customQuery =
                _context.Customers.AsSingleQuery()

            Customers cperson = new Customers();
            //cperson.Email = email;
            Entity.Customer foundcustomer = (Entity.Customer) customerQuery;
            //Entity.Customer foundcustomer = _context.Customers.Find(cperson.Email);
            cperson = _mapper.ParseCustomer(foundcustomer);
            return cperson;
        }

    }
}