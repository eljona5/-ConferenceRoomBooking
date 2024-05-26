using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.DataLayer.Repositories
{
  
        public class ReservationHolderRepository : IReservationHolderRepository
        {
            private readonly List<ReservationHolderModel> _reservationHolders;

            public ReservationHolderRepository()
            {
                // Initialize with some sample data for demonstration
        //        _reservationHolders = new List<ReservationHolderModel>
        //{
        //    new ReservationHolderModel { Id = 1, IdCardNumber = "123456789", Name = "Alice", Surname = "Smith", Email = "alice@example.com", PhoneNumber = "1234567890", Notes = "Guest speaker", BookingId = 1 },
        //    new ReservationHolderModel { Id = 2, IdCardNumber = "987654321", Name = "Bob", Surname = "Johnson", Email = "bob@example.com", PhoneNumber = "9876543210", Notes = "VIP guest", BookingId = 2 }
        //};
            }

            public void AddReservationHolder(ReservationHolderModel reservationHolder)
            {
                // Generate a unique Id for the new reservation holder
                reservationHolder.Id = _reservationHolders.Any() ? _reservationHolders.Max(rh => rh.Id) + 1 : 1;
                _reservationHolders.Add(reservationHolder);
            }

            public ReservationHolderModel GetReservationHolderById(int id)
            {
                return _reservationHolders.FirstOrDefault(rh => rh.Id == id);
            }

            public IEnumerable<ReservationHolderModel> GetReservationHoldersByBookingId(int bookingId)
            {
                return _reservationHolders.Where(rh => rh.BookingId == bookingId);
            }

            public void UpdateReservationHolder(ReservationHolderModel reservationHolder)
            {
                var existingHolder = _reservationHolders.FirstOrDefault(rh => rh.Id == reservationHolder.Id);
                if (existingHolder != null)
                {
                    existingHolder.IdCardNumber = reservationHolder.IdCardNumber;
                    existingHolder.Name = reservationHolder.Name;
                    existingHolder.Surname = reservationHolder.Surname;
                    existingHolder.Email = reservationHolder.Email;
                    existingHolder.PhoneNumber = reservationHolder.PhoneNumber;
                    existingHolder.Notes = reservationHolder.Notes;
                    existingHolder.BookingId = reservationHolder.BookingId;
                }
            }

            public void DeleteReservationHolder(int id)
            {
                var holderToRemove = _reservationHolders.FirstOrDefault(rh => rh.Id == id);
                if (holderToRemove != null)
                {
                    _reservationHolders.Remove(holderToRemove);
                }
            }
        }

    
}
