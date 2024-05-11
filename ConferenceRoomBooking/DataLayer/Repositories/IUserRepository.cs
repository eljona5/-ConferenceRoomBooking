using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.DataLayer.Repositories
{
    public interface IUserRepository
    {
        void AddUser(UserModel user);
        UserModel GetUserById(int id);
        IEnumerable<UserModel> GetAllUsers();
        void UpdateUser(UserModel user);
        void DeleteUser(int id);
    }
}
