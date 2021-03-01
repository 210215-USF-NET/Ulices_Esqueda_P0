namespace SModels
{
    public class OrderItem
    {
        public int OrderItemID { get; set; }
        public Product Product { get; set; }
        public int ProductQuantity { get; set; }
    }
}