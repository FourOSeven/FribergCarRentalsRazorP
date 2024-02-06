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

namespace FribergCarRentalsRazorP.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly IBooking bookingRepository;

        public IndexModel(IBooking bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }

        public IEnumerable<Booking> Bookings { get; set; } = default!;

        public void OnGet()
        {
            var customer = HttpContext.Session.GetInt32("CustomerId");
            if (customer == null)
            {
                Bookings = bookingRepository.GetAll();

            }
            else
            {
                Bookings = bookingRepository.GetAll().Where(b => b.Customer.Id == customer);
                
            }
        }
    }
}
