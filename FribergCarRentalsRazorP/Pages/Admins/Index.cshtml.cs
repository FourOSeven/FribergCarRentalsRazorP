﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergCarRentalsRazorP.Data;
using FribergCarRentalsRazorP.Data.Interfaces;

namespace FribergCarRentalsRazorP.Pages.Admins
{
    public class IndexModel : PageModel
    {
        private readonly IAdmin adminRepository;

        public IndexModel(IAdmin adminRepository)
        {

            this.adminRepository = adminRepository;
        }

        [BindProperty]
        public Admin Admin { get; set; } = default!;
        public IEnumerable<Admin> Admins { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(Admin admin)
        {
            Admins = adminRepository.GetAll();

            var adminFound = Admins.FirstOrDefault(c => c.Email == admin.Email && c.Password == admin.Password);
            if (adminFound != null)
            {   
                return RedirectToPage("./Home");
            }
            return Page();
        }
    }
}
