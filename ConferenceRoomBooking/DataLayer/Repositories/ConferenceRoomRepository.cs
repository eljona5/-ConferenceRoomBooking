using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.DataLayer.Repositories
{
    public class ConferenceRoomRepository : IConferenceRoomRepository
    {
        private readonly List<ConferenceRoomModel> _conferenceRooms;

        public ConferenceRoomRepository()
        {
            // Initialize with some sample data for demonstration
        //    _conferenceRooms = new List<ConferenceRoomModel>
        //{
        //    new ConferenceRoomModel { Id = 1, Code = "Room1", MaxCapacity = 10 },
        //    new ConferenceRoomModel { Id = 2, Code = "Room2", MaxCapacity = 15 }
        //};
        }

        public void AddConferenceRoom(ConferenceRoomModel conferenceRoom)
        {
            // Generate a unique Id for the new conference room
            conferenceRoom.Id = _conferenceRooms.Any() ? _conferenceRooms.Max(r => r.Id) + 1 : 1;
            _conferenceRooms.Add(conferenceRoom);
        }

        public ConferenceRoomModel GetConferenceRoomById(int id)
        {
            return _conferenceRooms.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<ConferenceRoomModel> GetAllConferenceRooms()
        {
            return _conferenceRooms;
        }

        public void UpdateConferenceRoom(ConferenceRoomModel conferenceRoom)
        {
            var existingRoom = _conferenceRooms.FirstOrDefault(r => r.Id == conferenceRoom.Id);
            if (existingRoom != null)
            {
                existingRoom.Code = conferenceRoom.Code;
                existingRoom.MaxCapacity = conferenceRoom.MaxCapacity;
            }
        }

        public void DeleteConferenceRoom(int id)
        {
            var roomToRemove = _conferenceRooms.FirstOrDefault(r => r.Id == id);
            if (roomToRemove != null)
            {
                _conferenceRooms.Remove(roomToRemove);
            }
        }
    }

}
