using ExpenseApp.Models;
using ExpenseApp.Repositories;

namespace ExpenseApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <inheritdoc/>
        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        /// <inheritdoc/>
        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        /// <inheritdoc/>
        public User GetUserByFullName(string firstName, string lastName)
        {
            return _userRepository.GetUserByFullName(firstName, lastName);
        }
    }
}
