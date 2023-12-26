using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication17.Data;
using WebApplication17.Models;

namespace WebApplication17.Pages.Admin.Products
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication17.Data.DnsDbContext _context;

        public DetailsModel(WebApplication17.Data.DnsDbContext context)
        {
            _context = context;
        }

        public Product Product { get; set; } = default!;
        public string CategoryName { get; set; }

        public async Task OnGetAsync(Guid? id)
        {
            if (_context.Products != null)
            {
                Product = await _context.Products.FindAsync(id);
                var category = await _context.Categorys.FindAsync(Product.CategoryId);
                CategoryName = category.Name;
            }
        }
    }
}
