using Microsoft.AspNetCore.Identity;

namespace WebApplication17.Models
{
    public class User : IdentityUser
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName {  get; set; }
        public List<Order> Orders { get; set; }
    }
}
