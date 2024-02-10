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
    public class DetailsModel : PageModel
    {
        private readonly IBooking bookingRepository;
        private readonly IAdmin adminRepository;
        private readonly ICustomer customerRepository;

        public DetailsModel(IBooking bookingRepository, IAdmin adminRepository, ICustomer customerRepository)
        {
            this.bookingRepository = bookingRepository;
            this.adminRepository = adminRepository;
            this.customerRepository = customerRepository;
        }

        public Booking Booking { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            if (AdminLoginCheck.IsAdminLoggedIn(HttpContext.Session.GetInt32("AdminId"), adminRepository) ||
                CustomerLoginCheck.IsCustomerLoggedIn(HttpContext.Session.GetInt32("CustomerId"), customerRepository))
            {
                var booking = bookingRepository.GetById(id);
                if (booking == null)
                {
                    return NotFound();
                }
                else
                {
                Booking = booking;
                }
                    return Page();
                }
            return RedirectToPage("/Index");          
        }
    }
}
