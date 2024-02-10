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
using FribergCarRentalsRazorP.Helpers;

namespace FribergCarRentalsRazorP.Pages.Vehicles
{
    public class IndexModel : PageModel
    {
        private readonly IVehicle vehicleRepository;
        private readonly IAdmin adminRepository;

        public IndexModel(IVehicle vehicleRepository, IAdmin adminRepository)
        {
            this.vehicleRepository = vehicleRepository;
            this.adminRepository = adminRepository;
        }

        public IEnumerable<Vehicle> Vehicles { get; set; } = default!;

        public IActionResult OnGet()
        {
            if (!AdminLoginCheck.IsAdminLoggedIn(HttpContext.Session.GetInt32("AdminId"), adminRepository))
            {
                return RedirectToPage("/Index");
            }
            Vehicles = vehicleRepository.GetAll();
            return Page();
        }
    }
}
