using FribergCarRentalsRazorP.Data.Interfaces;
using FribergCarRentalsRazorP.Data.Repositorys;
using FribergCarRentalsRazorP.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FribergCarRentalsRazorP.Pages.Admins
{
    public class LogoutModel : PageModel
    {
        private readonly IAdmin adminRepository;

        public LogoutModel(IAdmin adminRepository)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            HttpContext.Session.Remove("AdminId");
            HttpContext.Session.Remove("AdminCustomerId");
            return RedirectToPage("/Index");
        }
    }
}
