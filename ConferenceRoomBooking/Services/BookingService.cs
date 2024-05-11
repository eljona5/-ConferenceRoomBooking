using ConferenceRoomBooking.DataLayer.Repositories;
using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public void AddBooking(string code, int numPeople, bool isConfirmed, int roomId, DateTime startDate, DateTime endDate)
        {
            _bookingRepository.AddBooking(new BookingModel
            {
                Code = code,
                NumPeople = numPeople,
                IsConfirmed = isConfirmed,
                RoomId = roomId,
                StartDate = startDate,
                EndDate = endDate
            });
        }

        public BookingModel GetBookingById(int id)
        {
            return _bookingRepository.GetBookingById(id);
        }

        public IEnumerable<BookingModel> GetAllBookings()
        {
            return _bookingRepository.GetAllBookings();
        }

        public IEnumerable<BookingModel> GetBookingsByRoomId(int roomId)
        {
            return _bookingRepository.GetBookingsByRoomId(roomId);
        }

        public void UpdateBooking(int id, string code, int numPeople, bool isConfirmed, int roomId, DateTime startDate, DateTime endDate)
        {
            var booking = _bookingRepository.GetBookingById(id);
            if (booking != null)
            {
                booking.Code = code;
                booking.NumPeople = numPeople;
                booking.IsConfirmed = isConfirmed;
                booking.RoomId = roomId;
                booking.StartDate = startDate;
                booking.EndDate = endDate;
                _bookingRepository.UpdateBooking(booking);
            }
        }

        public void DeleteBooking(int id)
        {
            _bookingRepository.DeleteBooking(id);
        }
    }
}
