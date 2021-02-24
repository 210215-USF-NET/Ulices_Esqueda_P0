namespace Revature.Ulices_Esqueda_P0.StoreApp.SBL
{
    public class StoreBL : IStoreBL
    {
        private IStoreBL _repo;
        public StoreBL(IStorerepo repo){
            _repo = repo;
        }

        public List<Products> getInventory(){
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