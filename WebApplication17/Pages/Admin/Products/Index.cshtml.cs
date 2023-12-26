using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication17.Data;
using WebApplication17.Models;

namespace WebApplication17.Pages.Admin.Products
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly WebApplication17.Data.DnsDbContext _context;
        private readonly UserManager<User> _userManager;

        public IndexModel(DnsDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Product> Product { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await _context.Products
                .Include(p => p.Category).ToListAsync();
        }
        public async Task<IActionResult> OnPostAddToCart(Guid productId)
        {
            var user = await _userManager.GetUserAsync(User);
            var cartItems = new CartItems()
            {
                UserId = user.Id,
                ProductId = productId
            };
            _context.CartItems.Add(cartItems);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Admin/Products/Index");
        }
    }
}