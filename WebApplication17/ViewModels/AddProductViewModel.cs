namespace WebApplication17.ViewModels
{
    public class AddProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; } = 0;
        public decimal Skidka { get; set; } = 0;
        public string ImgUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
