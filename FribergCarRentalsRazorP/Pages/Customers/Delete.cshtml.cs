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
    public class DeleteModel : PageModel
    {
        private readonly ICustomer customerRepository;

        public DeleteModel(ICustomer customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
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

        public async Task<IActionResult> OnPostAsync(Customer customer)
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
