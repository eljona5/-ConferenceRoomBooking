using System.ComponentModel.DataAnnotations;

namespace ConferenceRoomBooking.DataLayer.Entities
{
    public class UnavailabilityPeriod
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}
