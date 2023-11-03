using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Models.Repo.Imple;

namespace Web.Pages.ProductionStepPage
{
    public class DetailsModel : PageModel
    {
        private readonly BirdManageRepo _birdManageRepo = new BirdManageRepo();

        public DetailsModel()
        {
            
        }

      public ProductionStep ProductionStep { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null ||_birdManageRepo.GetProductionSteps() == null)
            {
                return NotFound();
            }

            var productionstep = _birdManageRepo.getProductionStep(id);
            if (productionstep == null)
            {
                return NotFound();
            }
            else 
            {
                ProductionStep = productionstep;
            }
            return Page();
        }
    }
}
