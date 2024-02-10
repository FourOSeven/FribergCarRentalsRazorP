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
    public class DeleteModel : PageModel
    {
        private readonly ICustomer customerRepository;
        private readonly IAdmin adminRepository;

        public DeleteModel(ICustomer customerRepository, IAdmin adminRepository)
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
            if (id == null)
            {
                return NotFound();
            }

            var customer = customerRepository.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                Customer = customer;
            }
            return Page();
        }

        public IActionResult OnPost(Customer customer)
        {
            if (customer == null)
            {
                return NotFound();
            }
            else if (customer != null)
            {
                Customer = customer;
                customerRepository.Delete(customer);
            }
            return RedirectToPage("./Index");
        }
    }
}
