using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Services.Interfaces
{
    public interface IBookingService
    {
        void AddBooking(string code, int numPeople, bool isConfirmed, int roomId, DateTime startDate, DateTime endDate);
        IEnumerable<BookingModel> GetAllBookings();
        IEnumerable<BookingModel> GetBookingsByRoomId(int roomId);
        // Add other methods related to bookings
    }
}

