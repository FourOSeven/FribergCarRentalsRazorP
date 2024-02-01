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
    public class DeleteModel : PageModel
    {
        private readonly IVehicle vehicleRepository;

        public DeleteModel(IVehicle vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }

        [BindProperty]
        public Vehicle Vehicle { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
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

        public async Task<IActionResult> OnPostAsync(Vehicle vehicle)
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
