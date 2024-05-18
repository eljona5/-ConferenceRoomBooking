using ConferenceRoomBooking.DataLayer.Repositories;
using ConferenceRoomBooking.Models;
using ConferenceRoomBooking.Services.Interfaces;

namespace ConferenceRoomBooking.Services
{
    public class ConferenceRoomService : IConferenceRoomService
        {
            private readonly IConferenceRoomRepository _conferenceRoomRepository;

            public ConferenceRoomService(IConferenceRoomRepository conferenceRoomRepository)
            {
                _conferenceRoomRepository = conferenceRoomRepository;
            }

            public void AddConferenceRoom(string code, int maxCapacity)
            {
                var conferenceRoom = new ConferenceRoomModel { Code = code, MaxCapacity = maxCapacity };
                _conferenceRoomRepository.AddConferenceRoom(conferenceRoom);
            }

            public ConferenceRoomModel GetConferenceRoomById(int id)
            {
                return _conferenceRoomRepository.GetConferenceRoomById(id);
            }

            public IEnumerable<ConferenceRoomModel> GetAllConferenceRooms()
            {
                return _conferenceRoomRepository.GetAllConferenceRooms();
            }

            public void UpdateConferenceRoom(int id, string code, int maxCapacity)
            {
                var existingRoom = _conferenceRoomRepository.GetConferenceRoomById(id);
                if (existingRoom == null)
                {
                    throw new Exception("Conference room not found");
                }

                existingRoom.Code = code;
                existingRoom.MaxCapacity = maxCapacity;
                _conferenceRoomRepository.UpdateConferenceRoom(existingRoom);
            }

            public void DeleteConferenceRoom(int id)
            {
                var existingRoom = _conferenceRoomRepository.GetConferenceRoomById(id);
                if (existingRoom == null)
                {
                    throw new Exception("Conference room not found");
                }

                _conferenceRoomRepository.DeleteConferenceRoom(id);
            }
    }   
}

