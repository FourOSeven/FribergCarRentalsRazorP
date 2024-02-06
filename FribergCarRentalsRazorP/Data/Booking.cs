using System.ComponentModel.DataAnnotations;

namespace FribergCarRentalsRazorP.Data
{
    public class Booking
    {
        public int Id { get; set; } = 0;
        [DataType(DataType.Date)]
        public DateTime BookingStart { get; set; }
        [DataType(DataType.Date)]
        public DateTime BookingEnd { get; set; }
        public Customer Customer { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
