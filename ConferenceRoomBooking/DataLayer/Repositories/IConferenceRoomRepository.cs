using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.DataLayer.Repositories
{
    public interface IConferenceRoomRepository
    {
        void AddConferenceRoom(ConferenceRoomModel conferenceRoom);
        ConferenceRoomModel GetConferenceRoomById(int id);
        IEnumerable<ConferenceRoomModel> GetAllConferenceRooms();
        void UpdateConferenceRoom(ConferenceRoomModel conferenceRoom);
        void DeleteConferenceRoom(int id);
    }
}
