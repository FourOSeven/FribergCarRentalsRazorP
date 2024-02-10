
using FribergCarRentalsRazorP.Data.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FribergCarRentalsRazorP.Helpers
{
    public static class AdminLoginCheck
    {
        public static bool IsAdminLoggedIn(int? id, IAdmin adminRepository) 
        {
            var admin = adminRepository.GetById(id);
            if (admin==null)
            {
                return false;
            }
            return admin!=null;
        }
    }
}
