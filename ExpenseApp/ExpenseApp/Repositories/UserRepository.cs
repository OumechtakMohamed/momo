using ExpenseApp.Data;
using ExpenseApp.Models;

namespace ExpenseApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ExpenseContext _dbContext;

        public UserRepository(ExpenseContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public List<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        /// <inheritdoc/>
        public User GetUserById(int id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        /// <inheritdoc/>
        public User GetUserByFullName(string firstName, string lastName)
        {
            return _dbContext.Users.FirstOrDefault(u => u.FirstName == firstName && u.LastName == lastName);
        }
    }
}
