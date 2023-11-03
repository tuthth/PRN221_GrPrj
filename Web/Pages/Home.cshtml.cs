using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Models;

namespace Web.Pages
{
    public class HomeModel : PageModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnPost(string username, string password) {
            try
            {
                StaffAccount sa = new StaffAccount();
                IConfiguration config = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", true, true)
           .Build();
                sa.username = config["StaffAccount:Username"];
                sa.password = config["StaffAccount:Password"];

                if(username == sa.username &&  password == sa.password)
                {
                    HttpContext.Session.SetString("username", username);
                    return RedirectToPage("/ProductsPage/Index");
                }
                return Page();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}
