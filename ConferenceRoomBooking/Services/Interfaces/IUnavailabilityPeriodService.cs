using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Services.Interfaces
{
    public interface IUnavailabilityPeriodService
    {
        void AddUnavailabilityPeriod(DateTime startDate, DateTime endDate);
        IEnumerable<UnavailabilityPeriodModel> GetAllUnavailabilityPeriods();
        // Add other methods related to unavailability periods
    }
}
