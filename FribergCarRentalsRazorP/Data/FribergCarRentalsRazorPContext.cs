using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FribergCarRentalsRazorP.Data;

namespace FribergCarRentalsRazorP.Data
{
    public class FribergCarRentalsRazorPContext : DbContext
    {
        public FribergCarRentalsRazorPContext (DbContextOptions<FribergCarRentalsRazorPContext> options)
            : base(options)
        {
        }

        public DbSet<FribergCarRentalsRazorP.Data.Admin> Admins { get; set; } = default!;
        public DbSet<FribergCarRentalsRazorP.Data.Customer> Customers { get; set; } = default!;
        public DbSet<FribergCarRentalsRazorP.Data.Vehicle> Vehicles { get; set; } = default!;
        public DbSet<FribergCarRentalsRazorP.Data.Booking> Bookings { get; set; } = default!;
    }
}
