namespace WebApplication17.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? UserId { get; set; }
        public User User { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
    }
}