using FribergCarRentalsRazorP.Data.Interfaces;
using FribergCarRentalsRazorP.Data.Repositorys;
using FribergCarRentalsRazorP.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FribergCarRentalsRazorP.Pages.Bookings
{
    public class BookingSuccessModel : PageModel
    {
        private readonly IAdmin adminRepository;
        private readonly ICustomer customerRepository;

        public BookingSuccessModel(IAdmin adminRepository, ICustomer customerRepository)
        {
            this.adminRepository = adminRepository;
            this.customerRepository = customerRepository;
        }
        public IActionResult OnGet()
        {
            if (AdminLoginCheck.IsAdminLoggedIn(HttpContext.Session.GetInt32("AdminId"), adminRepository) ||
                CustomerLoginCheck.IsCustomerLoggedIn(HttpContext.Session.GetInt32("CustomerId"), customerRepository))
            {
                return Page();
            }
            return RedirectToPage("/Index");
        }
    }
}
