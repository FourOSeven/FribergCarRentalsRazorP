using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergCarRentalsRazorP.Data;
using FribergCarRentalsRazorP.Data.Interfaces;

namespace FribergCarRentalsRazorP.Pages.Bookings
{
    public class IndexVehicleBookingModel : PageModel
    {
        private readonly IVehicle vehicleRepository;

        public IndexVehicleBookingModel(IVehicle vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }

        public IEnumerable<Vehicle> Vehicles { get; set; } = default!;

        public async Task OnGetAsync(int? id)
        {
            if (id != null)
            {
                HttpContext.Session.SetInt32("AdminCustomerId", (int)id);
            }
            Vehicles = vehicleRepository.GetAll();
        }
    }
}
