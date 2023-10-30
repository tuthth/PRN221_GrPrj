using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Models.Repo.Imple;
using Models.Repo.Interface;

namespace Web.Pages.ProductsPage
{
    public class IndexModel : PageModel
    {
        private readonly BirdManageRepo _birdManageRepo = new BirdManageRepo();

        public IndexModel() { }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_birdManageRepo.getAllProducts().Count > 0)
            {
                Product = _birdManageRepo.getAllProducts();
            }
        }
    }
}
