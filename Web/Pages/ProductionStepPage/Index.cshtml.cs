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
    public class IndexModel : PageModel
    {
        private readonly Models.Models.BirdCageManagementsContext _context;

        public IndexModel(Models.Models.BirdCageManagementsContext context)
        {
            _context = context;
        }

        public IList<ProductionStep> ProductionStep { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ProductionSteps != null)
            {
                ProductionStep = await _context.ProductionSteps.ToListAsync();
            }
        }
    }
}
