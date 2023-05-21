namespace ExpenseApp.Models
{
    /// <summary>
    /// Représente un utilisateur.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Identifiant de l'utilisateur.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Prénom de l'utilisateur.
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Nom de famille de l'utilisateur.
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Devise de l'utilisateur.
        /// </summary>
        public string? Currency { get; set; }
    }
}
