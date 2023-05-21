using ExpenseApp.Models;
using System;
using System.Collections.Generic;

namespace ExpenseApp.Repositories
{
    /// <summary>
    /// Interface pour le repository des dépenses.
    /// </summary>
    public interface IExpenseRepository
    {
        /// <summary>
        /// Récupère la liste de toutes les dépenses.
        /// </summary>
        /// <returns>Liste des dépenses.</returns>
        List<Expense> GetAllExpenses();

        /// <summary>
        /// Récupère la liste des dépenses pour un utilisateur donné.
        /// </summary>
        /// <param name="userId">Identifiant de l'utilisateur.</param>
        /// <returns>Liste des dépenses de l'utilisateur.</returns>
        List<Expense> GetExpensesByUserId(int userId);

        /// <summary>
        /// Récupère une dépense par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant de la dépense.</param>
        /// <returns>Dépense correspondant à l'identifiant.</returns>
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

        /// <summary>
        /// Vérifie si une dépense est unique en fonction de la date, du montant et de l'identifiant de l'utilisateur.
        /// </summary>
        /// <param name="date">Date de la dépense.</param>
        /// <param name="amount">Montant de la dépense.</param>
        /// <param name="userId">Identifiant de l'utilisateur.</param>
        /// <returns>True si la dépense est unique, sinon False.</returns>
        bool IsExpenseUnique(DateTime date, decimal amount, int userId);
    }
}
