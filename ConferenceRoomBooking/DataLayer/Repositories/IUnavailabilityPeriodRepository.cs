using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.DataLayer.Repositories
{
    public interface IUnavailabilityPeriodRepository
    {
        void AddUnavailabilityPeriod(UnavailabilityPeriodModel unavailabilityPeriod);
        UnavailabilityPeriodModel GetUnavailabilityPeriodById(int id);
        IEnumerable<UnavailabilityPeriodModel> GetAllUnavailabilityPeriods();
        void UpdateUnavailabilityPeriod(UnavailabilityPeriodModel unavailabilityPeriod);
        void DeleteUnavailabilityPeriod(int id);
    }
}
