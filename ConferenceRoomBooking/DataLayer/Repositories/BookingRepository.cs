using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.DataLayer.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly List<BookingModel> _bookings;

        public BookingRepository()
        {
            // Initialize with some sample data for demonstration
            _bookings = new List<BookingModel>
        {
            new BookingModel { Id = 1, Code = "B001", NumberOfPeople = 5, IsConfirmed = true, RoomId = 1, StartDate = new DateTime(2024, 5, 12, 10, 0, 0), EndDate = new DateTime(2024, 5, 12, 12, 0, 0), IsDeleted = false },
            new BookingModel { Id = 2, Code = "B002", NumberOfPeople = 8, IsConfirmed = false, RoomId = 2, StartDate = new DateTime(2024, 5, 13, 14, 0, 0), EndDate = new DateTime(2024, 5, 13, 16, 0, 0), IsDeleted = false }
        };
        }

        public void AddBooking(BookingModel booking)
        {
            // Generate a unique Id for the new booking
            booking.Id = _bookings.Any() ? _bookings.Max(b => b.Id) + 1 : 1;
            _bookings.Add(booking);
        }

        public BookingModel GetBookingById(int id)
        {
            return _bookings.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<BookingModel> GetAllBookings()
        {
            return _bookings;
        }

        public IEnumerable<BookingModel> GetBookingsByRoomId(int roomId)
        {
            return _bookings.Where(b => b.RoomId == roomId);
        }

        public void UpdateBooking(BookingModel booking)
        {
            var existingBooking = _bookings.FirstOrDefault(b => b.Id == booking.Id);
            if (existingBooking != null)
            {
                existingBooking.Code = booking.Code;
                existingBooking.NumberOfPeople = booking.NumberOfPeople;
                existingBooking.IsConfirmed = booking.IsConfirmed;
                existingBooking.RoomId = booking.RoomId;
                existingBooking.StartDate = booking.StartDate;
                existingBooking.EndDate = booking.EndDate;
                existingBooking.IsDeleted = booking.IsDeleted;
            }
        }

        public void DeleteBooking(int id)
        {
            var bookingToRemove = _bookings.FirstOrDefault(b => b.Id == id);
            if (bookingToRemove != null)
            {
                _bookings.Remove(bookingToRemove);
            }
        }
    }
}
