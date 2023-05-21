using ExpenseApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseApp.Data
{
    /// <summary>
    /// Représente le contexte de la base de données pour les dépenses.
    /// </summary>
    public class ExpenseContext : DbContext
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="ExpenseContext"/>.
        /// </summary>
        /// <param name="options">Les options de configuration du contexte de dépenses.</param>
        public ExpenseContext(DbContextOptions<ExpenseContext> options) : base(options)
        {
        }

        /// <summary>
        /// Obtient ou définit la collection des utilisateurs.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Obtient ou définit la collection des dépenses.
        /// </summary>
        public DbSet<Expense> Expenses { get; set; }
    }
}
