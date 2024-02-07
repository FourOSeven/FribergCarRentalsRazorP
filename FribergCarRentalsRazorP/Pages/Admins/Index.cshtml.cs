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

        public IActionResult OnGet()
        {
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost(Admin admin)
        {
            Admins = adminRepository.GetAll();
            var adminFound = Admins.FirstOrDefault(c => c.Email == admin.Email && c.Password == admin.Password);
            if (adminFound != null)
            {
                HttpContext.Session.SetInt32("AdminId", adminFound.Id);
                return RedirectToPage("./Home");
            }
            ViewData["ErrorMessage"] = "Failed to login. Please check your email and/or password";
            return Page();
        }
    }
}
