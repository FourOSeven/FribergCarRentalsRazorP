using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FribergCarRentalsRazorP.Data;
using FribergCarRentalsRazorP.Data.Interfaces;
using FribergCarRentalsRazorP.Data.Repositorys;
using FribergCarRentalsRazorP.Helpers;

namespace FribergCarRentalsRazorP.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly ICustomer customerRepository;
        private readonly IAdmin adminRepository;

        public EditModel(ICustomer customerRepository, IAdmin adminRepository)
        {
            this.customerRepository = customerRepository;
            this.adminRepository = adminRepository;
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            if (!AdminLoginCheck.IsAdminLoggedIn(HttpContext.Session.GetInt32("AdminId"), adminRepository))
            {
                return RedirectToPage("/Index");
            }
            var customer = customerRepository.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            Customer = customer;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            customerRepository.Update(Customer);
            return RedirectToPage("./Index");
        }
    }    
}
