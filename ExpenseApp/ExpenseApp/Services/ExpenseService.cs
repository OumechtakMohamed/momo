using ExpenseApp.Models;
using ExpenseApp.Repositories;

namespace ExpenseApp.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IUserRepository _userRepository;

        public ExpenseService(IExpenseRepository expenseRepository, IUserRepository userRepository)
        {
            _expenseRepository = expenseRepository;
            _userRepository = userRepository;
        }

        /// <inheritdoc />
        public List<Expense> GetAllExpenses()
        {
            return _expenseRepository.GetAllExpenses();
        }

        /// <inheritdoc />
        public List<Expense> GetExpensesByUserId(int userId)
        {
            return _expenseRepository.GetExpensesByUserId(userId);
        }

        /// <inheritdoc />
        public Expense GetExpenseById(int id)
        {
            return _expenseRepository.GetExpenseById(id);
        }

        /// <inheritdoc />
        public void AddExpense(Expense expense)
        {
            // Vérifier si la dépense est null
            if (expense == null)
            {
                throw new ArgumentNullException(nameof(expense));
            }

            // Vérifier les règles de validation
            if (expense.Date > DateTime.Now)
            {
                throw new Exception("La date de la dépense ne peut pas être dans le futur.");
            }

            if (expense.Date < DateTime.Now.AddMonths(-3))
            {
                throw new Exception("La dépense ne peut pas être datée de plus de 3 mois.");
            }

            if (string.IsNullOrWhiteSpace(expense.Comment))
            {
                throw new Exception("Le commentaire est obligatoire pour la dépense.");
            }

            var user = _userRepository.GetUserById(expense.User!.Id);
            if (user == null)
            {
                throw new Exception("L'utilisateur associé à la dépense n'existe pas.");
            }

            if (expense.Currency != user.Currency)
            {
                throw new Exception("La devise de la dépense doit être identique à celle de l'utilisateur.");
            }

            if (!_expenseRepository.IsExpenseUnique(expense.Date, expense.Amount, expense.User!.Id))
            {
                throw new Exception("Un utilisateur ne peut pas déclarer deux fois la même dépense.");
            }

            _expenseRepository.AddExpense(expense);
        }

        /// <inheritdoc />
        public List<Expense> SortExpensesByAmount(bool ascending = true)
        {
            List<Expense> expenses = GetAllExpenses();
            if (ascending)
                expenses = expenses.OrderBy(e => e.Amount).ToList();
            else
                expenses = expenses.OrderByDescending(e => e.Amount).ToList();

            return expenses;
        }

        /// <inheritdoc />
        public List<Expense> SortExpensesByDate(bool ascending = true)
        {
            List<Expense> expenses = GetAllExpenses();
            if (ascending)
                expenses = expenses.OrderBy(e => e.Date).ToList();
            else
                expenses = expenses.OrderByDescending(e => e.Date).ToList();

            return expenses;
        }

        /// <inheritdoc />
        public void RemoveExpense(Expense expense)
        {
            // Vérifier si la dépense est null
            if (expense == null)
            {
                throw new ArgumentNullException(nameof(expense));
            }

            _expenseRepository.RemoveExpense(expense);
        }
    }
}
