using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergCarRentalsRazorP.Data;
using FribergCarRentalsRazorP.Data.Interfaces;

namespace FribergCarRentalsRazorP.Pages.Admins
{
    public class IndexModel : PageModel
    {
        private readonly IAdmin adminRepository;

        public IndexModel(IAdmin adminRepository)
        {

            this.adminRepository = adminRepository;
        }
        public IEnumerable<Admin> Admins { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Admins = adminRepository.GetAll();//await _context.Admins.ToListAsync();
        }
    }
}
