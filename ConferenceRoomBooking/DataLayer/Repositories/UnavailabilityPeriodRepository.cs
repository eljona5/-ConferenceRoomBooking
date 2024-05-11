using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.DataLayer.Repositories
{
    public class UnavailabilityPeriodRepository : IUnavailabilityPeriodRepository
    {
        private readonly List<UnavailabilityPeriodModel> _unavailabilityPeriods;

        public UnavailabilityPeriodRepository()
        {
            // Initialize with some sample data for demonstration
            _unavailabilityPeriods = new List<UnavailabilityPeriodModel>
        {
            new UnavailabilityPeriodModel { Id = 1, StartDate = new DateTime(2024, 5, 20), EndDate = new DateTime(2024, 5, 25) },
            new UnavailabilityPeriodModel { Id = 2, StartDate = new DateTime(2024, 6, 10), EndDate = new DateTime(2024, 6, 15) }
        };
        }

        public void AddUnavailabilityPeriod(UnavailabilityPeriodModel unavailabilityPeriod)
        {
            // Generate a unique Id for the new unavailability period
            unavailabilityPeriod.Id = _unavailabilityPeriods.Any() ? _unavailabilityPeriods.Max(up => up.Id) + 1 : 1;
            _unavailabilityPeriods.Add(unavailabilityPeriod);
        }

        public UnavailabilityPeriodModel GetUnavailabilityPeriodById(int id)
        {
            return _unavailabilityPeriods.FirstOrDefault(up => up.Id == id);
        }

        public IEnumerable<UnavailabilityPeriodModel> GetAllUnavailabilityPeriods()
        {
            return _unavailabilityPeriods;
        }

        public void UpdateUnavailabilityPeriod(UnavailabilityPeriodModel unavailabilityPeriod)
        {
            var existingPeriod = _unavailabilityPeriods.FirstOrDefault(up => up.Id == unavailabilityPeriod.Id);
            if (existingPeriod != null)
            {
                existingPeriod.StartDate = unavailabilityPeriod.StartDate;
                existingPeriod.EndDate = unavailabilityPeriod.EndDate;
            }
        }

        public void DeleteUnavailabilityPeriod(int id)
        {
            var periodToRemove = _unavailabilityPeriods.FirstOrDefault(up => up.Id == id);
            if (periodToRemove != null)
            {
                _unavailabilityPeriods.Remove(periodToRemove);
            }
        }
    }
}
