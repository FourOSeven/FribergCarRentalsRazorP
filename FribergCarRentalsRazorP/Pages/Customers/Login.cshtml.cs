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


namespace FribergCarRentalsRazorP.Pages.Customers
{
    public class LoginModel : PageModel
    {
        private readonly ICustomer customerRepository;

        public LoginModel(ICustomer customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;
        public IEnumerable<Customer> Customers { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost(Customer customer)
        {
            Customers = customerRepository.GetAll();
            
            var customerFound = Customers.FirstOrDefault(c => c.Email == customer.Email && c.Password == customer.Password);
            if (customerFound != null)
            {
                HttpContext.Session.SetInt32("CustomerId", customerFound.Id);
                return RedirectToPage("./Home");
            }
            ViewData["ErrorMessage"] = "Failed to login. Please check your email and/or password";
            return Page();       
        }
    }
}
