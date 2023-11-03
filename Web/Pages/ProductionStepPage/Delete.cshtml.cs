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
    public class DeleteModel : PageModel
    {
        private readonly BirdManageRepo _birdManagRepo = new BirdManageRepo();

        public DeleteModel()
        {
            
        }

        [BindProperty]
      public ProductionStep ProductionStep { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("/Logout");
            }
            if (id == null || _birdManagRepo.GetProductionSteps() == null)
            {
                return NotFound();
            }

            var productionstep = _birdManagRepo.getProductionStep(id);

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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null || _birdManagRepo.GetProductionSteps() == null)
            {
                return NotFound();
            }
            var productionstep = _birdManagRepo.getProductionStep(id);

            if (productionstep != null)
            {
                ProductionStep = productionstep;
                await _birdManagRepo.deleteProductionStep(productionstep);
            }

            return RedirectToPage("./Index");
        }
    }
}
