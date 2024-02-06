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
    public class DeleteModel : PageModel
    {
        private readonly IAdmin adminRepository;

        public DeleteModel(IAdmin adminRepository)
        {

            this.adminRepository = adminRepository;
        }

        [BindProperty]
        public Admin Admin { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

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

        public IActionResult OnPost(Admin admin)
        {
            if (admin == null)
            {
                return NotFound();
            }
            else if (admin != null)
            {
                Admin = admin;
                adminRepository.Delete(admin);
            }
            return RedirectToPage("./Home");
        }
    }
}
