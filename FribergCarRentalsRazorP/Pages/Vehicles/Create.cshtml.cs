using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FribergCarRentalsRazorP.Data;
using FribergCarRentalsRazorP.Data.Repositorys;
using FribergCarRentalsRazorP.Data.Interfaces;

namespace FribergCarRentalsRazorP.Pages.Vehicles
{
    public class CreateModel : PageModel
    {
        private readonly IVehicle vehicleRepository;

        public CreateModel(IVehicle vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Vehicle Vehicle { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    vehicleRepository.Add(Vehicle);
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
