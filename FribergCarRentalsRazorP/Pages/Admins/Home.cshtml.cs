using FribergCarRentalsRazorP.Data.Interfaces;
using FribergCarRentalsRazorP.Data.Repositorys;
using FribergCarRentalsRazorP.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FribergCarRentalsRazorP.Pages.Admins
{
    public class HomeModel : PageModel
    {
        private readonly IAdmin adminRepository;

        public HomeModel(IAdmin adminRepository)
        {
            this.adminRepository = adminRepository;
        }
        public IActionResult OnGet()
        {
            if (!AdminLoginCheck.IsAdminLoggedIn(HttpContext.Session.GetInt32("AdminId"), adminRepository))
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
