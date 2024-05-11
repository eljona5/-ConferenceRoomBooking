using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ConferenceRoomBooking.DataLayer.Entities
{
    public class ReservationHolder
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string IdCardNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Notes { get; set; }
        [Required]
        public int BookingId { get; set; }
        [ForeignKey("BookingId")]
        public Booking Booking { get; set; }
    }
}
