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
    public class DeleteModel : PageModel
    {
        private readonly IVehicle vehicleRepository;
        private readonly IAdmin adminRepository;

        public DeleteModel(IVehicle vehicleRepository, IAdmin adminRepository)
        {
            this.vehicleRepository = vehicleRepository;
            this.adminRepository = adminRepository;
        }

        [BindProperty]
        public Vehicle Vehicle { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            if (!AdminLoginCheck.IsAdminLoggedIn(HttpContext.Session.GetInt32("AdminId"), adminRepository))
            {
                return RedirectToPage("/Index");
            }
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = vehicleRepository.GetById(id);

            if (vehicle == null)
            {
                return NotFound();
            }
            else
            {
                Vehicle = vehicle;
            }
            return Page();
        }

        public IActionResult OnPost(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                return NotFound();
            }
            else if (vehicle != null)
            {
                Vehicle = vehicle;
                vehicleRepository.Delete(vehicle);
            }
            return RedirectToPage("./Index");
        } 
    }
}
