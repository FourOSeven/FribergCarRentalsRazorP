using FribergCarRentalsRazorP.Data.Interfaces;

namespace FribergCarRentalsRazorP.Helpers
{
    public static class CustomerLoginCheck
    {
        public static bool IsAdminLoggedIn(int? id, ICustomer customerRepository)
        {
            var customer = customerRepository.GetById(id);
            if (customer == null)
            {
                return false;
            }
            return customer != null;
        }
    }
}
