using ExpenseApp.Data;
using ExpenseApp.Models;

namespace ExpenseApp.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ExpenseContext _dbContext;

        public ExpenseRepository(ExpenseContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc />
        public List<Expense> GetAllExpenses()
        {
            return _dbContext.Expenses.ToList();
        }

        /// <inheritdoc />
        public List<Expense> GetExpensesByUserId(int userId)
        {
            return _dbContext.Expenses.Where(e => e.UserId == userId).ToList();
        }

        /// <inheritdoc />
        public Expense? GetExpenseById(int id)
        {
            return _dbContext.Expenses.FirstOrDefault(e => e.Id == id);
        }

        /// <inheritdoc />
        public void AddExpense(Expense expense)
        {
            _dbContext.Expenses.Add(expense);
            _dbContext.SaveChanges();
        }

        /// <inheritdoc />
        public void RemoveExpense(Expense expense)
        {
            _dbContext.Expenses.Remove(expense);
            _dbContext.SaveChanges();
        }

        /// <inheritdoc />
        public bool IsExpenseUnique(DateTime date, decimal amount, int userId)
        {
            return !_dbContext.Expenses.Any(e => e.Date == date && e.Amount == amount && e.UserId == userId);
        }
    }
}
