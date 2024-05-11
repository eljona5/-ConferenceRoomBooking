using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Services
{
    public interface IConferenceRoomService
    {

        void AddConferenceRoom(string code, int maxCapacity);
        ConferenceRoomModel GetConferenceRoomById(int id);
        IEnumerable<ConferenceRoomModel> GetAllConferenceRooms();
        void UpdateConferenceRoom(int id, string code, int maxCapacity);
        void DeleteConferenceRoom(int id);
    }
}
