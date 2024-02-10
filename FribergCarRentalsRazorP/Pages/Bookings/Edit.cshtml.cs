using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FribergCarRentalsRazorP.Data;
using FribergCarRentalsRazorP.Data.Interfaces;
using FribergCarRentalsRazorP.Data.Repositorys;
using Azure.Core.GeoJson;
using FribergCarRentalsRazorP.Helpers;

namespace FribergCarRentalsRazorP.Pages.Bookings
{
    public class EditModel : PageModel
    {
        private readonly IBooking bookingRepository;
        private readonly ICustomer customerRepository;
        private readonly IAdmin adminRepository;

        public EditModel(IBooking bookingRepository, ICustomer customerRepository, IAdmin adminRepository)
        {
            this.bookingRepository = bookingRepository;
            this.customerRepository = customerRepository;
            this.adminRepository = adminRepository;
        }

        [BindProperty]
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
                Booking = booking;
                return Page();
            }
            return RedirectToPage("/Index");     
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            bookingRepository.Update(Booking);
            return RedirectToPage("./Index");
        }
    }
}
