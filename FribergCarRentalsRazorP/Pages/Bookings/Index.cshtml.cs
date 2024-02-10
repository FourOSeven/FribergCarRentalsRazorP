using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergCarRentalsRazorP.Data;
using FribergCarRentalsRazorP.Data.Interfaces;
using FribergCarRentalsRazorP.Data.Repositorys;
using FribergCarRentalsRazorP.Helpers;

namespace FribergCarRentalsRazorP.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly IBooking bookingRepository;
        private readonly IAdmin adminRepository;
        private readonly ICustomer customerRepository;

        public IndexModel(IBooking bookingRepository, IAdmin adminRepository, ICustomer customerRepository)
        {
            this.bookingRepository = bookingRepository;
            this.adminRepository = adminRepository;
            this.customerRepository = customerRepository;
        }

        public IEnumerable<Booking> Bookings { get; set; } = default!;

        public IActionResult OnGet()
        {
            if (AdminLoginCheck.IsAdminLoggedIn(HttpContext.Session.GetInt32("AdminId"), adminRepository) ||
                CustomerLoginCheck.IsCustomerLoggedIn(HttpContext.Session.GetInt32("CustomerId"), customerRepository))
            {
                var customer = HttpContext.Session.GetInt32("CustomerId");
                var admin = HttpContext.Session.GetInt32("AdminId");
                if (customer != null)
                { 
                    Bookings = bookingRepository.GetAll().Where(b => b.Customer.Id == customer);  
                    return Page();
                }
                else if (admin != null)
                {
                   Bookings = bookingRepository.GetAll();   
                    return Page();  
                }
            }
            return RedirectToPage("/Index");           
        }
    }
}
