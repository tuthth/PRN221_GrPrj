﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Models;
using Models.Repo.Imple;

namespace Web.Pages.ProductionStepPage
{
    public class CreateModel : PageModel
    {
        private readonly BirdManageRepo _birdManageRepo = new BirdManageRepo();

        public CreateModel()
        {
            
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ProductionStep ProductionStep { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid ||_birdManageRepo.GetProductionSteps() == null || ProductionStep == null)
            {
                return Page();
            }

            await _birdManageRepo.createProductionStep(ProductionStep);
            return RedirectToPage("./Index");
        }
    }
}
