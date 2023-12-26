using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication17.Data;
using WebApplication17.Models;

namespace WebApplication17.Pages.Cart
{
    public class IndexModel : PageModel
    {
        private readonly DnsDbContext _context;
        private readonly UserManager<User> _userManager;

        public IndexModel(DnsDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public List<CartItems> CartItems { get; set; } = new List<CartItems>();
        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                CartItems = await _context.CartItems.Include(ci=>ci.Product).Where(ci=>ci.UserId==user.Id).ToListAsync();
            }
        }
        public async Task<IActionResult> OnPostDeleteAsync(Guid productid)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                var cartItem = await _context.CartItems
                    .Include(ci => ci.Product)
                    .FirstOrDefaultAsync(ci => ci.UserId == user.Id && ci.Product.Id == productid);
                if (cartItem != null)
                {
                    _context.CartItems.Remove(cartItem);
                    await _context.SaveChangesAsync();
                }
            }
            return RedirectToPage("/Cart/Index");
        }
        public async Task<IActionResult> OnPostOrderAsync(Guid productid)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                var cartItem = await _context.CartItems
                    .Include(ci => ci.Product)
                    .FirstOrDefaultAsync(ci => ci.UserId == user.Id && ci.Product.Id == productid);
                if (cartItem != null)
                {
                    var order = new Order()
                    {
                        Name = Guid.NewGuid().ToString(),
                        UserId = user.Id,
                        User = user,
                        OrderProducts = new List<OrderProduct>()
                        { 
                            new OrderProduct()
                            {
                                ProductId = productid, 
                                Count = 1
                            }
                        }

                    };
                    _context.Orders.Add(order);
                    _context.CartItems.Remove(cartItem);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("/Cart/OrderDetails", new {Id=order.Id});
                }
            }
            return RedirectToPage("/Cart/Index");
        }
    }
}
