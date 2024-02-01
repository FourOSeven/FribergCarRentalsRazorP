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
    public class DeleteModel : PageModel
    {
        private readonly IBooking bookingRepository;

        public DeleteModel(IBooking bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

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

        public async Task<IActionResult> OnPostAsync(Booking booking)
        {
            if (booking == null)
            {
                return NotFound();
            }
            else if (booking != null)
            {
                Booking = booking;
                bookingRepository.Delete(booking);
            }
            return RedirectToPage("./Index");
        }
    }
}
