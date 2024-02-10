using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergCarRentalsRazorP.Data;
using FribergCarRentalsRazorP.Data.Interfaces;
using FribergCarRentalsRazorP.Data.Repositorys;
using FribergCarRentalsRazorP.Helpers;

namespace FribergCarRentalsRazorP.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly ICustomer customerRepository;
        private readonly IAdmin adminRepository;

        public IndexModel(ICustomer customerRepository, IAdmin adminRepository)
        {
            this.customerRepository = customerRepository;
            this.adminRepository = adminRepository;
        }
        public IEnumerable<Customer> Customers { get; set; } = default!;

        public IActionResult OnGet()
        {
            if(!AdminLoginCheck.IsAdminLoggedIn(HttpContext.Session.GetInt32("AdminId"), adminRepository))
            {
               return RedirectToPage("/Index");
            }
            Customers = customerRepository.GetAll();
            return Page();
        }
    }
}
