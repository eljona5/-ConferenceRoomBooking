using ConferenceRoomBooking.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConferenceRoomBooking.DataLayer.Entities
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public int NumberOfPeople { get; set; }

        [Required]
        public bool IsConfirmed { get; set; }

        [Required]
        public int RoomId { get; set; }

        [ForeignKey("RoomId")]
        public ConferenceRoom Room { get; set; }
        //public int ReservationId { get; set; }

       // [ForeignKey("ReservationHolderId")]
       //public ReservationHolder ReservationHolder{ get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        public bool IsDeleted { get; set; }


    }
}
