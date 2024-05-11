using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.DataLayer.Repositories
{
    public interface IReservationHolderRepository
    {
        void AddReservationHolder(ReservationHolderModel reservationHolder);
        ReservationHolderModel GetReservationHolderById(int id);
        IEnumerable<ReservationHolderModel> GetReservationHoldersByBookingId(int bookingId);
        void UpdateReservationHolder(ReservationHolderModel reservationHolder);
        void DeleteReservationHolder(int id);
    }
}
