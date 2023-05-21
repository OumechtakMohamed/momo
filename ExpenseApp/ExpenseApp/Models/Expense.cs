namespace ExpenseApp.Models
{
    /// <summary>
    /// Représente une dépense.
    /// </summary>
    public class Expense
    {
        /// <summary>
        /// Obtient ou définit l'identifiant de la dépense.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtient ou définit l'identifiant de l'utilisateur associé à la dépense.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Obtient ou définit l'utilisateur associé à la dépense.
        /// </summary>
        public User? User { get; set; }

        /// <summary>
        /// Obtient ou définit la date de la dépense.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Obtient ou définit la nature de la dépense.
        /// </summary>
        public ExpenseNature Nature { get; set; }

        /// <summary>
        /// Obtient ou définit le montant de la dépense.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Obtient ou définit la devise de la dépense.
        /// </summary>
        public string? Currency { get; set; }

        /// <summary>
        /// Obtient ou définit le commentaire de la dépense.
        /// </summary>
        public string? Comment { get; set; }
    }
}
