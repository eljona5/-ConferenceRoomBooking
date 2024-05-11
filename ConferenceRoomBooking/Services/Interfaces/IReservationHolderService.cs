using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Services.Interfaces
{
    public interface IReservationHolderService
    {
        void AddReservationHolder(string idCardNumber, string name, string surname, string email, string phoneNumber, string notes, int bookingId);
        IEnumerable<ReservationHolderModel> GetReservationHoldersByBookingId(int bookingId);
        // Add other methods related to reservation holders
    }
}
