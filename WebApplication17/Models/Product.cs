namespace WebApplication17.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost{ get; set; } = 0;
        public decimal Skidka { get; set; } = 0;
        public string ImgUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<OrderProduct> OrderProducts { get; set;} = new List<OrderProduct>();
    }
}
