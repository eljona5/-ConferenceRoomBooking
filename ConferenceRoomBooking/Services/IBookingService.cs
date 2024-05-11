using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Services
{
    public interface IBookingService
    {
        void AddBooking(string code, int numPeople, bool isConfirmed, int roomId, DateTime startDate, DateTime endDate);
        BookingModel GetBookingById(int id);
        IEnumerable<BookingModel> GetAllBookings();
        IEnumerable<BookingModel> GetBookingsByRoomId(int roomId);
        void UpdateBooking(int id, string code, int numPeople, bool isConfirmed, int roomId, DateTime startDate, DateTime endDate);
        void DeleteBooking(int id);
    }
}
