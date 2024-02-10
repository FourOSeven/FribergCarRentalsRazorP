using FribergCarRentalsRazorP.Data.Interfaces;
using FribergCarRentalsRazorP.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FribergCarRentalsRazorP.Pages.Customers
{
    public class HomeModel : PageModel
    {
        private readonly ICustomer customerRepository;

        public HomeModel(ICustomer customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public IActionResult OnGet()
        {
            if (!CustomerLoginCheck.IsCustomerLoggedIn(HttpContext.Session.GetInt32("CustomerId"), customerRepository))
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
