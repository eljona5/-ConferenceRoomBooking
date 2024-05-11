using System.ComponentModel.DataAnnotations;

namespace ConferenceRoomBooking.DataLayer.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }
}
