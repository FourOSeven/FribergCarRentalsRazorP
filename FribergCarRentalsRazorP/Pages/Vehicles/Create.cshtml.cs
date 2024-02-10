﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FribergCarRentalsRazorP.Data;
using FribergCarRentalsRazorP.Data.Repositorys;
using FribergCarRentalsRazorP.Data.Interfaces;
using FribergCarRentalsRazorP.Helpers;

namespace FribergCarRentalsRazorP.Pages.Vehicles
{
    public class CreateModel : PageModel
    {
        private readonly IVehicle vehicleRepository;
        private readonly IAdmin adminRepository;

        public CreateModel(IVehicle vehicleRepository, IAdmin adminRepository)
        {
            this.vehicleRepository = vehicleRepository;
            this.adminRepository = adminRepository;
        }

        public IActionResult OnGet()
        {
            if (!AdminLoginCheck.IsAdminLoggedIn(HttpContext.Session.GetInt32("AdminId"), adminRepository))
            {
                return RedirectToPage("/Index");
            }
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
