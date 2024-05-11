using ConferenceRoomBooking.DataLayer.Repositories;
using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Services
{
    public class ReservationHolderService : IReservationHolderService
    {
        private readonly IReservationHolderRepository _reservationHolderRepository;

        public ReservationHolderService(IReservationHolderRepository reservationHolderRepository)
        {
            _reservationHolderRepository = reservationHolderRepository;
        }

        public void AddReservationHolder(string idCardNumber, string name, string surname, string email, string phoneNumber, string notes, int bookingId)
        {
            _reservationHolderRepository.AddReservationHolder(new ReservationHolderModel
            {
                IdCardNumber = idCardNumber,
                Name = name,
                Surname = surname,
                Email = email,
                PhoneNumber = phoneNumber,
                Notes = notes,
                BookingId = bookingId
            });
        }

        public ReservationHolderModel GetReservationHolderById(int id)
        {
            return _reservationHolderRepository.GetReservationHolderById(id);
        }

        public IEnumerable<ReservationHolderModel> GetReservationHoldersByBookingId(int bookingId)
        {
            return _reservationHolderRepository.GetReservationHoldersByBookingId(bookingId);
        }

        public void UpdateReservationHolder(int id, string idCardNumber, string name, string surname, string email, string phoneNumber, string notes, int bookingId)
        {
            var reservationHolder = _reservationHolderRepository.GetReservationHolderById(id);
            if (reservationHolder != null)
            {
                reservationHolder.IdCardNumber = idCardNumber;
                reservationHolder.Name = name;
                reservationHolder.Surname = surname;
                reservationHolder.Email = email;
                reservationHolder.PhoneNumber = phoneNumber;
                reservationHolder.Notes = notes;
                reservationHolder.BookingId = bookingId;
                _reservationHolderRepository.UpdateReservationHolder(reservationHolder);
            }
        }

        public void DeleteReservationHolder(int id)
        {
            _reservationHolderRepository.DeleteReservationHolder(id);
        }
    }
}

