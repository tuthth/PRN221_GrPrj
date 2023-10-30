using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Models;

namespace Web.Pages.ProductionStepPage
{
    public class CreateModel : PageModel
    {
        private readonly Models.Models.BirdCageManagementsContext _context;

        public CreateModel(Models.Models.BirdCageManagementsContext context)
        {
            _context = context;
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
          if (!ModelState.IsValid || _context.ProductionSteps == null || ProductionStep == null)
            {
                return Page();
            }

            _context.ProductionSteps.Add(ProductionStep);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
