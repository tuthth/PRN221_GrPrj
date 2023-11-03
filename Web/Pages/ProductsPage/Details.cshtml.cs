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
    public class DetailsModel : PageModel
    {
        private readonly BirdManageRepo _birdManageRepo = new BirdManageRepo();

        public DetailsModel()
        {
           
        }

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
    }
}
