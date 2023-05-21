using ExpenseApp.Models;
using System.Collections.Generic;

namespace ExpenseApp.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Récupère la liste de tous les utilisateurs.
        /// </summary>
        /// <returns>La liste des utilisateurs.</returns>
        List<User> GetAllUsers();

        /// <summary>
        /// Récupère un utilisateur par son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant de l'utilisateur.</param>
        /// <returns>L'utilisateur correspondant à l'identifiant spécifié.</returns>
        User GetUserById(int id);

        /// <summary>
        /// Récupère un utilisateur par son prénom et son nom complet.
        /// </summary>
        /// <param name="firstName">Le prénom de l'utilisateur.</param>
        /// <param name="lastName">Le nom de famille de l'utilisateur.</param>
        /// <returns>L'utilisateur correspondant au prénom et au nom spécifiés.</returns>
        User GetUserByFullName(string firstName, string lastName);
    }
}
