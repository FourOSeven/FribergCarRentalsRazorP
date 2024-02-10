using FribergCarRentalsRazorP.Data;
using FribergCarRentalsRazorP.Data.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FribergCarRentalsRazorP.Pages.Bookings
{
    public class IndexVehicleBookingModel : PageModel
    {
        private readonly IVehicle vehicleRepository;
        private readonly IAdmin adminRepository;
        private readonly ICustomer customerRepository;

        public IndexVehicleBookingModel(IVehicle vehicleRepository, IAdmin adminRepository, ICustomer customerRepository)
        {
            this.vehicleRepository = vehicleRepository;
            this.adminRepository = adminRepository;
            this.customerRepository = customerRepository;
        }

        public IEnumerable<Vehicle> Vehicles { get; set; } = default!;

        public void OnGet(int? id)
        {
            if (id != null)
            {
                HttpContext.Session.SetInt32("AdminCustomerId", (int)id);
            }
            Vehicles = vehicleRepository.GetAll();
        }
    }
}
