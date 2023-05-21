using ExpenseApp.Models;

namespace ExpenseApp.ViewModels
{
    /// <summary>
    /// Représente le ViewModel d'une dépense à afficher.
    /// </summary>
    public class ExpenseViewModel
    {
        /// <summary>
        /// Obtient ou définit l'identifiant de la dépense.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtient ou définit le nom complet de l'utilisateur associé à la dépense.
        /// </summary>
        public string? User { get; set; }

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
