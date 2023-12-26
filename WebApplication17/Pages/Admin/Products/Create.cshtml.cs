using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication17.Data;
using WebApplication17.Models;
using WebApplication17.ViewModels;

namespace WebApplication17.Pages.Admin.Products
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication17.Data.DnsDbContext _context;

        public CreateModel(WebApplication17.Data.DnsDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categorys, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public AddProductViewModel AddProductView { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage();
            }
            var product = new Product()
            {
                Name = AddProductView.Name,
                Description = AddProductView.Description,
                CategoryId = AddProductView.CategoryId,
                Cost = AddProductView.Cost,
                ImgUrl = AddProductView.ImgUrl,
                Skidka = AddProductView.Skidka
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
