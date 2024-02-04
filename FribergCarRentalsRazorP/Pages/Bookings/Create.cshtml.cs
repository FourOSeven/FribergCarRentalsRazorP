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
        public IEnumerable<Vehicle> Vehicles { get; set; }
        public IActionResult OnGet(int? id,int? vehicleId)
        {
            Vehicles = vehicleRepository.GetAll();
            var vehicle = Vehicles.FirstOrDefault(v=>v.Id == vehicleId);
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            if (id != null)
            {
                var customer =  customerRepository.GetById(id);
                Booking = CustomerDataInsert(customer, vehicle);
            }
            else
            {
                var customer = customerRepository.GetById(customerId);
                Booking = CustomerDataInsert(customer, vehicle);
            }
            return Page();
        }
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
