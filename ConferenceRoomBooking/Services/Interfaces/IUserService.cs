using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Services.Interfaces
{
    public interface IUserService
    {
        void AddUser(string name, string surname, string email);
        IEnumerable<UserModel> GetAllUsers();
        // Add other methods related to users
    }
}
