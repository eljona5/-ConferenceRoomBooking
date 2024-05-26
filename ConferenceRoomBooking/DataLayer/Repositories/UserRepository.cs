using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.DataLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<UserModel> _users;

        public UserRepository()
        {
            // Initialize with some sample data for demonstration
        //    _users = new List<UserModel>
        //{
        //    new UserModel { Id = 1, Name = "John", Surname = "Doe", Email = "john@example.com", IsDeleted = false },
        //    new UserModel { Id = 2, Name = "Jane", Surname = "Smith", Email = "jane@example.com", IsDeleted = false }
        //};
        }

        public void AddUser(UserModel user)
        {
            // Generate a unique Id for the new user
            user.Id = _users.Any() ? _users.Max(u => u.Id) + 1 : 1;
            _users.Add(user);
        }

        public UserModel GetUserById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            return _users;
        }

        public void UpdateUser(UserModel user)
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Surname = user.Surname;
                existingUser.Email = user.Email;
                existingUser.IsDeleted = user.IsDeleted;
            }
        }

        public void DeleteUser(int id)
        {
            var userToRemove = _users.FirstOrDefault(u => u.Id == id);
            if (userToRemove != null)
            {
                _users.Remove(userToRemove);
            }
        }
    }

}
