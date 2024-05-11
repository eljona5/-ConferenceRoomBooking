using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Services
{
    public interface IReservationHolderService
    {
        void AddReservationHolder(string idCardNumber, string name, string surname, string email, string phoneNumber, string notes, int bookingId);
        ReservationHolderModel GetReservationHolderById(int id);
        IEnumerable<ReservationHolderModel> GetReservationHoldersByBookingId(int bookingId);
        void UpdateReservationHolder(int id, string idCardNumber, string name, string surname, string email, string phoneNumber, string notes, int bookingId);
        void DeleteReservationHolder(int id);
    }
}
