using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergCarRentalsRazorP.Data;
using FribergCarRentalsRazorP.Data.Interfaces;
using FribergCarRentalsRazorP.Helpers;

namespace FribergCarRentalsRazorP.Pages.Admins
{
    public class ListModel : PageModel
    {
        private readonly IAdmin adminRepository;

        public ListModel(IAdmin adminRepository)
        {

            this.adminRepository = adminRepository;
        }
        public IEnumerable<Admin> Admins { get; set; } = default!;

        public IActionResult OnGet()
        {
            if (!AdminLoginCheck.IsAdminLoggedIn(HttpContext.Session.GetInt32("AdminId"), adminRepository))
            {
                return RedirectToPage("/Index");
            }
            Admins = adminRepository.GetAll();
            return Page();
        }
    }
}
