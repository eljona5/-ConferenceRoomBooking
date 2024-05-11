using ConferenceRoomBooking.DataLayer.Repositories;
using ConferenceRoomBooking.Models;
using ConferenceRoomBooking.Services.Interfaces;

namespace ConferenceRoomBooking.Services
{
    public class UnavailabilityPeriodService : IUnavailabilityPeriodService
    {
        private readonly IUnavailabilityPeriodRepository _unavailabilityPeriodRepository;

        public UnavailabilityPeriodService(IUnavailabilityPeriodRepository unavailabilityPeriodRepository)
        {
            _unavailabilityPeriodRepository = unavailabilityPeriodRepository;
        }

        public void AddUnavailabilityPeriod(DateTime startDate, DateTime endDate)
        {
            _unavailabilityPeriodRepository.AddUnavailabilityPeriod(new UnavailabilityPeriodModel
            {
                StartDate = startDate,
                EndDate = endDate
            });
        }

        public UnavailabilityPeriodModel GetUnavailabilityPeriodById(int id)
        {
            return _unavailabilityPeriodRepository.GetUnavailabilityPeriodById(id);
        }

        public IEnumerable<UnavailabilityPeriodModel> GetAllUnavailabilityPeriods()
        {
            return _unavailabilityPeriodRepository.GetAllUnavailabilityPeriods();
        }

        public void UpdateUnavailabilityPeriod(int id, DateTime startDate, DateTime endDate)
        {
            var unavailabilityPeriod = _unavailabilityPeriodRepository.GetUnavailabilityPeriodById(id);
            if (unavailabilityPeriod != null)
            {
                unavailabilityPeriod.StartDate = startDate;
                unavailabilityPeriod.EndDate = endDate;
                _unavailabilityPeriodRepository.UpdateUnavailabilityPeriod(unavailabilityPeriod);
            }
        }

        public void DeleteUnavailabilityPeriod(int id)
        {
            _unavailabilityPeriodRepository.DeleteUnavailabilityPeriod(id);
        }
    }
}
