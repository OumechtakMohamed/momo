using ExpenseApp.Models;
using ExpenseApp.Repositories;

namespace ExpenseApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        /// <inheritdoc/>
        public List<User> GetAllUsers()
        {
            _logger.LogInformation("Getting all users");

            List<User> users = _userRepository.GetAllUsers();

            _logger.LogInformation("Retrieved all users");

            return users;
        }

        /// <inheritdoc/>
        public User? GetUserById(int id)
        {
            _logger.LogInformation("Getting user by ID: {id}", id);

            User user = _userRepository.GetUserById(id);

            if (user == null)
            {
                _logger.LogInformation("User not found with ID: {id}", id);
            }
            else
            {
                _logger.LogInformation("Retrieved user: {id} - {firstName} {lastName}", user.Id, user.FirstName, user.LastName);
            }

            return user;
        }

        /// <inheritdoc/>
        public User? GetUserByFullName(string firstName, string lastName)
        {
            _logger.LogInformation("Getting user by full name: {firstName} {lastName}", firstName, lastName);

            User user = _userRepository.GetUserByFullName(firstName, lastName);

            if (user == null)
            {
                _logger.LogInformation("User not found with full name: {firstName} {lastName}", firstName, lastName);
            }
            else
            {
                _logger.LogInformation("Retrieved user: {id} - {firstName} {lastName}", user.Id, user.FirstName, user.LastName);
            }

            return user;
        }
    }
}
