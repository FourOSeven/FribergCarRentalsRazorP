using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FribergCarRentalsRazorP.Data;
using FribergCarRentalsRazorP.Data.Interfaces;

namespace FribergCarRentalsRazorP.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly ICustomer customerRepository;

        public CreateModel(ICustomer customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    customerRepository.Add(Customer);
                }
                return RedirectToPage("./Index");
            }
            catch
            {
                return Page();
            }
        }
    }
}
