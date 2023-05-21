using ExpenseApp.Models;

namespace ExpenseApp.Services
{
    public interface IExpenseService
    {
        /// <summary>
        /// Récupère la liste de toutes les dépenses.
        /// </summary>
        List<Expense> GetAllExpenses();

        /// <summary>
        /// Récupère la liste des dépenses pour un utilisateur donné.
        /// </summary>
        /// <param name="userId">Identifiant de l'utilisateur.</param>
        List<Expense> GetExpensesByUserId(int userId);

        /// <summary>
        /// Récupère la liste des dépenses triées par montant.
        /// </summary>
        /// <param name="ascending">Indique si le tri est ascendant (true) ou descendant (false).</param>
        List<Expense> SortExpensesByAmount(bool ascending = true);

        /// <summary>
        /// Récupère la liste des dépenses triées par date.
        /// </summary>
        /// <param name="ascending">Indique si le tri est ascendant (true) ou descendant (false).</param>
        List<Expense> SortExpensesByDate(bool ascending = true);

        /// <summary>
        /// Récupère une dépense par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant de la dépense.</param>
        Expense GetExpenseById(int id);

        /// <summary>
        /// Ajoute une nouvelle dépense.
        /// </summary>
        /// <param name="expense">La dépense à ajouter.</param>
        void AddExpense(Expense expense);

        /// <summary>
        /// Supprime une dépense.
        /// </summary>
        /// <param name="expense">La dépense à supprimer.</param>
        void RemoveExpense(Expense expense);
    }
}
