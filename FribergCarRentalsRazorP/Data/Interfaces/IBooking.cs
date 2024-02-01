namespace FribergCarRentalsRazorP.Data.Interfaces
{
    public interface IBooking
    {
        Booking GetById(int id);
        IEnumerable<Booking> GetAll();
        void Add(Booking booking);
        void Update(Booking booking);
        void Delete(Booking booking);
    }
}
