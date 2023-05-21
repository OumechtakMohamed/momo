using ExpenseApp.Models;
using System.ComponentModel.DataAnnotations;

namespace ExpenseApp.ViewModels
{
        /// <summary>
        /// Représente les informations nécessaires pour créer une nouvelle dépense.
        /// </summary>
        public class ExpenseCreateViewModel
        {
            /// <summary>
            /// Obtient ou définit l'identifiant de l'utilisateur associé à la dépense.
            /// </summary>
            public int UserId { get; set; }

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
