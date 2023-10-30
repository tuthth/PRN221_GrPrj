using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace Web.Pages.ProductionStepPage
{
    public class DetailsModel : PageModel
    {
        private readonly Models.Models.BirdCageManagementsContext _context;

        public DetailsModel(Models.Models.BirdCageManagementsContext context)
        {
            _context = context;
        }

      public ProductionStep ProductionStep { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ProductionSteps == null)
            {
                return NotFound();
            }

            var productionstep = await _context.ProductionSteps.FirstOrDefaultAsync(m => m.StepId == id);
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
