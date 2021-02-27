namespace SModels
{
    public class TrackOrder
    {
        public int TrackOrderID { get; set; }
        public Customers Customer { get; set; }
        public Orders Order { get; set; }
        public OrderItem OrderItem { get; set; }
        public Store Store { get; set; }
    }
}