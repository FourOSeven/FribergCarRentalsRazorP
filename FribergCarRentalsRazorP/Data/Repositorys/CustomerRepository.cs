using FribergCarRentalsRazorP.Data.Interfaces;

namespace FribergCarRentalsRazorP.Data.Repositorys
{
    public class CustomerRepository : ICustomer
    {
        private readonly FribergCarRentalsRazorPContext FribergCarRentalsRazorPContext;

        public CustomerRepository(FribergCarRentalsRazorPContext FribergCarRentalsRazorPContext)
        {
            this.FribergCarRentalsRazorPContext = FribergCarRentalsRazorPContext;
        }

        public void Add(Customer customer)
        {
            FribergCarRentalsRazorPContext.Customers.Add(customer);
            FribergCarRentalsRazorPContext.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            FribergCarRentalsRazorPContext.Customers.Remove(customer);
            FribergCarRentalsRazorPContext.SaveChanges();
        }

        public IEnumerable<Customer> GetAll()
        {
            return FribergCarRentalsRazorPContext.Customers.OrderBy(x => x.LastName);
        }

        public Customer GetById(int id)
        {
            return FribergCarRentalsRazorPContext.Customers.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Customer customer)
        {
            FribergCarRentalsRazorPContext.Customers.Update(customer);
            FribergCarRentalsRazorPContext.SaveChanges();
        }
    }
}
