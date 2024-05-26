namespace ConferenceRoomBooking.Models
{
    public class ConferenceRoomModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int MaxCapacity { get; set; }
        public string? PhotoPath { get; set; }
        public bool IsDeleted { get; set; }
    }
}
