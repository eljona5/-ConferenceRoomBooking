using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.DataLayer.Repositories
{
    public interface IBookingRepository
    {
        void AddBooking(BookingModel booking);
        BookingModel GetBookingById(int id);
        IEnumerable<BookingModel> GetAllBookings();
        IEnumerable<BookingModel> GetBookingsByRoomId(int roomId);
        void UpdateBooking(BookingModel booking);
        void DeleteBooking(int id);
    }
}
