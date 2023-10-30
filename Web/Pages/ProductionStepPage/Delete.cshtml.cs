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
    public class DeleteModel : PageModel
    {
        private readonly Models.Models.BirdCageManagementsContext _context;

        public DeleteModel(Models.Models.BirdCageManagementsContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ProductionSteps == null)
            {
                return NotFound();
            }
            var productionstep = await _context.ProductionSteps.FindAsync(id);

            if (productionstep != null)
            {
                ProductionStep = productionstep;
                _context.ProductionSteps.Remove(ProductionStep);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
