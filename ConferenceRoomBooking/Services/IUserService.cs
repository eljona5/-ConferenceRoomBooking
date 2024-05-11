using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Services
{
    public interface IUserService
    {
        void AddUser(string name, string surname, string email);
        UserModel GetUserById(int id);
        IEnumerable<UserModel> GetAllUsers();
        void UpdateUser(int id, string name, string surname, string email);
        void DeleteUser(int id);
    }
}
