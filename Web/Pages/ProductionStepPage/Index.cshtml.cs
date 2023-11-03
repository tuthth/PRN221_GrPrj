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
    public class IndexModel : PageModel
    {
        private readonly BirdManageRepo _birdManageRepo = new BirdManageRepo();

        public IndexModel()
        {
            
        }

        public IList<ProductionStep> ProductionStep { get;set; } = default!;

        public IActionResult OnGetAsync()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("/Logout");
            }
            if (_birdManageRepo.GetProductionSteps() != null)
            {
                ProductionStep = _birdManageRepo.GetProductionSteps();
            }
            return Page();
        }
    }
}
