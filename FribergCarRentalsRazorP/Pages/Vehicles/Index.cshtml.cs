using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergCarRentalsRazorP.Data;
using FribergCarRentalsRazorP.Data.Repositorys;
using FribergCarRentalsRazorP.Data.Interfaces;

namespace FribergCarRentalsRazorP.Pages.Vehicles
{
    public class IndexModel : PageModel
    {
        private readonly IVehicle vehicleRepository;

        public IndexModel(IVehicle vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }

        public IEnumerable<Vehicle> Vehicles { get; set; } = default!;

        public void OnGet()
        {
            Vehicles = vehicleRepository.GetAll();//await _context.Admins.ToListAsync();
        }
    }
}
