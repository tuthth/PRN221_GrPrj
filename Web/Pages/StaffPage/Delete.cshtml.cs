using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Models.Repo.Imple;

namespace Web.Pages.StaffPage
{
    public class DeleteModel : PageModel
    {
        private readonly BirdManageRepo _birdManageRepo = new BirdManageRepo();

        public DeleteModel()
        {
           
        }

        [BindProperty]
      public Staff Staff { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || _birdManageRepo.getAllStaffs() == null)
            {
                return NotFound();
            }

            var staff = _birdManageRepo.getStaff(id);

            if (staff == null)
            {
                return NotFound();
            }
            else 
            {
                Staff = staff;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null || _birdManageRepo.getAllStaffs() == null)
            {
                return NotFound();
            }
            var staff = _birdManageRepo.getStaff(id);

            if (staff != null)
            {
                Staff = staff;
                await _birdManageRepo.deleteStaff(staff);
            }

            return RedirectToPage("./Index");
        }
    }
}
