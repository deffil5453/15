using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication17.Data;
using WebApplication17.Models;
using WebApplication17.ViewModels;

namespace WebApplication17.Pages.Admin.Products
{
    public class EditModel : PageModel
    {
        private readonly WebApplication17.Data.DnsDbContext _context;

        public EditModel(WebApplication17.Data.DnsDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EditProductViewModel EditProduct { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            var product = _context.Products.Find(id);
            ViewData["CategoryId"] = new SelectList(_context.Categorys, "Id", "Name");
            if (product != null)
            {
                EditProduct = new EditProductViewModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Cost = product.Cost,
                    CategoryId = product.CategoryId,
                    Skidka = product.Skidka,
                    ImgUrl = product.ImgUrl
                };
            }
            return Page();
        }
        public async Task OnPostAsync(Guid id)
        {
            if (EditProduct!=null)
            {
                var productAsync = await _context.Products.FindAsync(id);
                productAsync.Name = EditProduct.Name;
                productAsync.Description = EditProduct.Description;
                productAsync.Cost = EditProduct.Cost;
                productAsync.CategoryId = EditProduct.CategoryId;
                productAsync.ImgUrl = EditProduct.ImgUrl;
                productAsync.Skidka = EditProduct.Skidka;
                await _context.SaveChangesAsync();
            }
        }
    }
}