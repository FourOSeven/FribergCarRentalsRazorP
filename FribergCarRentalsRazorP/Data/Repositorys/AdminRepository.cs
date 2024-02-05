using FribergCarRentalsRazorP.Data.Interfaces;

namespace FribergCarRentalsRazorP.Data.Repositorys
{
    public class AdminRepository : IAdmin
    {
        private readonly FribergCarRentalsRazorPContext FribergCarRentalsRazorPContext;

        public AdminRepository(FribergCarRentalsRazorPContext FribergCarRentalsRazorPDbContext)
        {
            this.FribergCarRentalsRazorPContext = FribergCarRentalsRazorPDbContext;
        }
        public void Add(Admin admin)
        {
            FribergCarRentalsRazorPContext.Admins.Add(admin);
            FribergCarRentalsRazorPContext.SaveChanges();
        }

        public void Delete(Admin admin)
        {
            FribergCarRentalsRazorPContext.Admins.Remove(admin);
            FribergCarRentalsRazorPContext.SaveChanges();
        }

        public IEnumerable<Admin> GetAll()
        {
            return FribergCarRentalsRazorPContext.Admins.OrderBy(a => a.LastName);
        }

        public Admin GetById(int id)
        {
            return FribergCarRentalsRazorPContext.Admins.FirstOrDefault(a => a.Id == id);
        }

        public void Update(Admin admin)
        {
            FribergCarRentalsRazorPContext.Admins.Update(admin);
            FribergCarRentalsRazorPContext.SaveChanges();
        }
    }
}
