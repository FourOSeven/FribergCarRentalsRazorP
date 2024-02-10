using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FribergCarRentalsRazorP.Data;
using FribergCarRentalsRazorP.Data.Repositorys;
using FribergCarRentalsRazorP.Helpers;
using FribergCarRentalsRazorP.Data.Interfaces;

namespace FribergCarRentalsRazorP.Pages.Customers
{
    public class LogoutModel : PageModel
    {
        private readonly ICustomer customerRepository;

        public LogoutModel(ICustomer customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public IActionResult OnGet()
        {           
            if (!CustomerLoginCheck.IsCustomerLoggedIn(HttpContext.Session.GetInt32("CustomerId"), customerRepository))
            {
                   return RedirectToPage("/Index"); 
            }
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
