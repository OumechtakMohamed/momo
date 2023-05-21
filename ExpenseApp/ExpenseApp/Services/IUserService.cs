using ExpenseApp.Models;

namespace ExpenseApp.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Récupère tous les utilisateurs.
        /// </summary>
        /// <returns>La liste des utilisateurs.</returns>
        List<User> GetAllUsers();

        /// <summary>
        /// Récupère un utilisateur par son ID.
        /// </summary>
        /// <param name="id">L'ID de l'utilisateur.</param>
        /// <returns>L'utilisateur correspondant à l'ID.</returns>
        User GetUserById(int id);

        /// <summary>
        /// Récupère un utilisateur par son nom complet.
        /// </summary>
        /// <param name="firstName">Le prénom de l'utilisateur.</param>
        /// <param name="lastName">Le nom de famille de l'utilisateur.</param>
        /// <returns>L'utilisateur correspondant au nom complet.</returns>
        User GetUserByFullName(string firstName, string lastName);
    }
}
