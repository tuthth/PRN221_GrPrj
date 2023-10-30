using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace Web.Pages.ProductionStepPage
{
    public class EditModel : PageModel
    {
        private readonly Models.Models.BirdCageManagementsContext _context;

        public EditModel(Models.Models.BirdCageManagementsContext context)
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

            var productionstep =  await _context.ProductionSteps.FirstOrDefaultAsync(m => m.StepId == id);
            if (productionstep == null)
            {
                return NotFound();
            }
            ProductionStep = productionstep;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ProductionStep).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductionStepExists(ProductionStep.StepId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductionStepExists(int id)
        {
          return (_context.ProductionSteps?.Any(e => e.StepId == id)).GetValueOrDefault();
        }
    }
}
