using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication17.Data;
using WebApplication17.Models;

namespace WebApplication17.Pages.Cart
{
    public class OrderDetailsModel : PageModel
    {
        private readonly DnsDbContext _context;

        public OrderDetailsModel(DnsDbContext context)
        {
            _context = context;
        }
        public Order Order { get; set; }
        public async Task OnGetAsync(Guid Id)
        {
            Order = await _context.Orders
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                .Include(o => o.User)
                .FirstOrDefaultAsync(o=>o.Id==Id);
        }   
    }
}