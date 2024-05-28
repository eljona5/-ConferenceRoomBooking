namespace ConferenceRoomBooking.Models
{
    public class UnavailabilityPeriod
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsDeleted { get; set; }
    }

}
