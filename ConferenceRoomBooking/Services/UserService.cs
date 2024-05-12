using ConferenceRoomBooking.DataLayer.Repositories;
using ConferenceRoomBooking.Models;
using ConferenceRoomBooking.Services.Interfaces;

namespace ConferenceRoomBooking.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(string name, string surname, string email)
        {
            _userRepository.AddUser(new UserModel { Name = name, Surname = surname, Email = email });
        }

        public UserModel GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public void UpdateUser(int id, string name, string surname, string email)
        {
            var user = _userRepository.GetUserById(id);
            if (user != null)
            {
                user.Name = name;
                user.Surname = surname;
                user.Email = email;
                _userRepository.UpdateUser(user);
            }
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }
    }
}
