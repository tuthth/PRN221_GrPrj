using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Models.Repo.Imple;

namespace Web.Pages.StaffPage
{
    public class EditModel : PageModel
    {
        private readonly BirdManageRepo _birdManageRepo = new BirdManageRepo();

        public EditModel()
        {
            
        }

        [BindProperty]
        public Staff Staff { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("/Logout");
            }
            if (id == null || _birdManageRepo.getAllStaffs() == null)
            {
                return NotFound();
            }

            var staff = _birdManageRepo.getStaff(id);
            if (staff == null)
            {
                return NotFound();
            }
            Staff = staff;
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

            try
            {
                await _birdManageRepo.updateStaff(Staff);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return RedirectToPage("./Index");
        }

    }
}
