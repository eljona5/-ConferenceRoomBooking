namespace ConferenceRoomBooking.Models
{
    public class ReservationHolder
    {
        public int Id { get; set; }
        public string IdCardNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Notes { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
    }

}
