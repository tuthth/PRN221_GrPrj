using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Models.Repo.Imple;

namespace Web.Pages.ProductsPage
{
    public class DeleteModel : PageModel
    {
        private readonly BirdManageRepo _birdManageRepo = new BirdManageRepo();

        public DeleteModel()
        {
           
        }

        [BindProperty]
      public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("/Logout");
            }
            if (id == null || _birdManageRepo.getAllProducts() == null)
            {
                return NotFound();
            }

            var product = _birdManageRepo.getProductById(id);

            if (product == null)
            {
                return NotFound();
            }
            else 
            {
                Product = product;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null || _birdManageRepo.getAllProducts() == null)
            {
                return NotFound();
            }

            var product = _birdManageRepo.getProductById(id);

            if (product != null)
            {
                Product = product;
                await _birdManageRepo.deleteProduct(product);
            }

            return RedirectToPage("./Index");
        }
    }
}
