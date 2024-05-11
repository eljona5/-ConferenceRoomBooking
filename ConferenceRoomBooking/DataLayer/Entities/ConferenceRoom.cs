using System.ComponentModel.DataAnnotations;

namespace ConferenceRoomBooking.DataLayer.Entities
{
    public class ConferenceRoom
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public int MaximumCapacity { get; set; }
    }
}
