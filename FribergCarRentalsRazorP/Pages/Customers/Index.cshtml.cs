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
    public class IndexModel : PageModel
    {
        private readonly ICustomer customerRepository;

        public IndexModel(ICustomer customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public IEnumerable<Customer> Customers { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Customers = customerRepository.GetAll();//await _context.Admins.ToListAsync();
        }
    }
}
