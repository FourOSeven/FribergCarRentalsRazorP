using FribergCarRentalsRazorP.Data.Interfaces;

namespace FribergCarRentalsRazorP.Data.Repositorys
{
    public class VehicleRepository : IVehicle
    {
        private readonly FribergCarRentalsRazorPContext FribergCarRentalsRazorPContext;

        public VehicleRepository(FribergCarRentalsRazorPContext FribergCarRentalsRazorPContext)
        {
            this.FribergCarRentalsRazorPContext = FribergCarRentalsRazorPContext;
        }

        public void Add(Vehicle vehicle)
        {
            FribergCarRentalsRazorPContext.Add<Vehicle>(vehicle);
            FribergCarRentalsRazorPContext.SaveChanges();
        }

        public void Delete(Vehicle vehicle)
        {
            FribergCarRentalsRazorPContext.Remove<Vehicle>(vehicle);
            FribergCarRentalsRazorPContext.SaveChanges();
        }

        public IEnumerable<Vehicle> GetAll()
        {
            return FribergCarRentalsRazorPContext.Vehicles.OrderBy(v => v.Make);
        }

        public Vehicle GetById(int id)
        {
            return FribergCarRentalsRazorPContext.Vehicles.FirstOrDefault(v => v.Id == id);
        }

        public void Update(Vehicle vehicle)
        {
            FribergCarRentalsRazorPContext.Update<Vehicle>(vehicle);
            FribergCarRentalsRazorPContext.SaveChanges();
        }
    }
}
