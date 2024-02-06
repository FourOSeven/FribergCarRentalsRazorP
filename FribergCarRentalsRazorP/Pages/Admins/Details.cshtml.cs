using System;
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
    public class DetailsModel : PageModel
    {
        private readonly IAdmin adminRepository;

        public DetailsModel(IAdmin adminRepository)
        {

            this.adminRepository = adminRepository;
        }
        public Admin Admin { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            var admin = adminRepository.GetById(id);
            if (admin == null)
            {
                return NotFound();
            }
            else
            {
                Admin = admin;
            }
            return Page();
        }
    }
}
