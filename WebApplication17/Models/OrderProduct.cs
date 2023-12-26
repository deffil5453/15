namespace WebApplication17.Models
{
    public class OrderProduct
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public int Count { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
