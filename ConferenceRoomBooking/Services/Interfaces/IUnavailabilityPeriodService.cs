using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Services.Interfaces
{
    public interface IUnavailabilityPeriodService
    {
        void AddUnavailabilityPeriod(DateTime startDate, DateTime endDate);
        UnavailabilityPeriodModel GetUnavailabilityPeriodById(int id);
        IEnumerable<UnavailabilityPeriodModel> GetAllUnavailabilityPeriods();
        void UpdateUnavailabilityPeriod(int id, DateTime startDate, DateTime endDate);
        void DeleteUnavailabilityPeriod(int id);
    }
}
