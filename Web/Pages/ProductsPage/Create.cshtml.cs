﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Models;
using Models.Repo.Imple;

namespace Web.Pages.ProductsPage
{
    public class CreateModel : PageModel
    {
        private readonly BirdManageRepo _birdManageRepo = new BirdManageRepo();

        public CreateModel()
        {
        }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("/Logout");
            }
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;
        

        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _birdManageRepo.getAllProducts() == null || Product == null)
            {
                return Page();
            }

            await _birdManageRepo.addProduct(Product);

            return RedirectToPage("./Index");
        }
    }
}
