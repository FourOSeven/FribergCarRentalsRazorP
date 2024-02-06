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

namespace FribergCarRentalsRazorP.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly ICustomer customerRepository;

        public DetailsModel(ICustomer customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Customer Customer { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
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
    }
}
