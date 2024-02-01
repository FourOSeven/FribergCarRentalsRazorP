using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FribergCarRentalsRazorP.Data;
using FribergCarRentalsRazorP.Data.Interfaces;
using FribergCarRentalsRazorP.Data.Repositorys;

namespace FribergCarRentalsRazorP.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly IBooking bookingRepository;

        public CreateModel(IBooking bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bookingRepository.Add(Booking);
                }
                return RedirectToPage("./Index");
            }
            catch
            {
                return Page();
            }
        }
    }
}
