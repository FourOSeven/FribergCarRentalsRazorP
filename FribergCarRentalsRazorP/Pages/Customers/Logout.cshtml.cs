using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FribergCarRentalsRazorP.Data;

namespace FribergCarRentalsRazorP.Pages.Customers
{
    public class LogoutModel : PageModel
    {
        private readonly FribergCarRentalsRazorP.Data.FribergCarRentalsRazorPContext _context;

        public LogoutModel(FribergCarRentalsRazorP.Data.FribergCarRentalsRazorPContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            HttpContext.Session.Remove("CustomerId");
            return RedirectToPage("/Index");
        }
    }
}
