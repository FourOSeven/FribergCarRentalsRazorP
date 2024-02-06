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
        private readonly ICustomer customerRepository;
        private readonly IVehicle vehicleRepository;

        public CreateModel(IBooking bookingRepository, ICustomer customerRepository, IVehicle vehicleRepository)
        {
            this.bookingRepository = bookingRepository;
            this.customerRepository = customerRepository;
            this.vehicleRepository = vehicleRepository;
        }
        [BindProperty]
        public Booking Booking { get; set; } = default!;
        public IActionResult OnGet(int vehicleId)
        {
            var vehicle = vehicleRepository.GetById(vehicleId);
            var customerId = HttpContext.Session.GetInt32("CustomerId");           
            var adminCustomerId = HttpContext.Session.GetInt32("AdminCustomerId");
            if (adminCustomerId != null)
            {
                var customer =  customerRepository.GetById(adminCustomerId);
                Booking = CustomerDataInsert(customer, vehicle);
            }        
            else if (customerId != null)
            {
                var customer = customerRepository.GetById(customerId);
                Booking = CustomerDataInsert(customer, vehicle);
            }
            else
            {
                TempData["NotLoggedIn"] = " You need to be logged in to book a vehilce.";
                return RedirectToPage("/Customers/Login");
            }
            return Page();
        }
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bookingRepository.Add(Booking);
                    var adminCustomerId = HttpContext.Session.GetInt32("AdminCustomerId");
                   if(adminCustomerId != null)
                    {
                        return RedirectToPage("/Admins/Home");
                    }
                }
                return RedirectToPage("./BookingSuccess");
            }
            catch
            {
                return Page();
            }
        }
        public Booking CustomerDataInsert(Customer customer, Vehicle vehicle)
        {
            return new Booking {
                BookingStart = DateTime.Now,
                BookingEnd = DateTime.Now,
                Customer = customer,
                Vehicle = vehicle
            };
        }
    }
}
