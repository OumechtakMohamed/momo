using ExpenseApp.Models;
using ExpenseApp.Repositories;

namespace ExpenseApp.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<ExpenseService> _logger;

        public ExpenseService(IExpenseRepository expenseRepository, IUserRepository userRepository, ILogger<ExpenseService> logger)
        {
            _expenseRepository = expenseRepository;
            _userRepository = userRepository;
            _logger = logger;
        }

        /// <inheritdoc />
        public List<Expense> GetAllExpenses()
        {
            _logger.LogInformation("Getting all expenses");

            List<Expense> expenses = _expenseRepository.GetAllExpenses();

            _logger.LogInformation("Retrieved {count} expenses", expenses.Count);

            return expenses;
        }

        /// <inheritdoc />
        public List<Expense> GetExpensesByUserId(int userId)
        {
            _logger.LogInformation("Getting expenses for user with ID {userId}", userId);

            List<Expense> expenses = _expenseRepository.GetExpensesByUserId(userId);

            _logger.LogInformation("Retrieved {count} expenses for user with ID {userId}", expenses.Count, userId);

            return expenses;
        }

        /// <inheritdoc />
        public Expense? GetExpenseById(int id)
        {
            _logger.LogInformation("Getting expense with ID {id}", id);

            Expense expense = _expenseRepository.GetExpenseById(id);

            if (expense == null)
            {
                _logger.LogWarning("Expense with ID {id} not found", id);
            }
            else
            {
                _logger.LogInformation("Retrieved expense with ID {id}", id);
            }

            return expense;
        }

        /// <inheritdoc />
        public void AddExpense(Expense expense)
        {
            _logger.LogInformation("Adding new expense");

            // Vérifier si la dépense est null
            if (expense == null)
            {
                _logger.LogError("Expense object is null");
                throw new ArgumentNullException(nameof(expense));
            }

            // Vérifier les règles de validation
            if (expense.Date > DateTime.Now)
            {
                _logger.LogError("Expense date cannot be in the future");
                throw new Exception("La date de la dépense ne peut pas être dans le futur.");
            }

            if (expense.Date < DateTime.Now.AddMonths(-3))
            {
                _logger.LogError("Expense date cannot be more than 3 months ago");
                throw new Exception("La dépense ne peut pas être datée de plus de 3 mois.");
            }

            if (string.IsNullOrWhiteSpace(expense.Comment))
            {
                _logger.LogError("Expense comment is required");
                throw new Exception("Le commentaire est obligatoire pour la dépense.");
            }

            var user = _userRepository.GetUserById(expense.User!.Id);
            if (user == null)
            {
                _logger.LogError("User associated with the expense does not exist");
                throw new Exception("L'utilisateur associé à la dépense n'existe pas.");
            }

            if (expense.Currency != user.Currency)
            {
                _logger.LogError("Expense currency must be identical to user's currency");
                throw new Exception("La devise de la dépense doit être identique à celle de l'utilisateur.");
            }

            if (!_expenseRepository.IsExpenseUnique(expense.Date, expense.Amount, expense.User!.Id))
            {
                _logger.LogError("User cannot declare the same expense twice");
                throw new Exception("Un utilisateur ne peut pas déclarer deux fois la même dépense.");
            }

            _expenseRepository.AddExpense(expense);

            _logger.LogInformation("Expense added successfully");
        }

        /// <inheritdoc />
        public List<Expense> SortExpensesByAmount(bool ascending = true)
        {
            _logger.LogInformation("Sorting expenses by amount");

            List<Expense> expenses = GetAllExpenses();

            if (ascending)
            {
                expenses = expenses.OrderBy(e => e.Amount).ToList();
            }
            else
            {
                expenses = expenses.OrderByDescending(e => e.Amount).ToList();
            }

            _logger.LogInformation("Expenses sorted by amount");

            return expenses;
        }

        /// <inheritdoc />
        public List<Expense> SortExpensesByDate(bool ascending = true)
        {
            _logger.LogInformation("Sorting expenses by date");

            List<Expense> expenses = GetAllExpenses();

            if (ascending)
            {
                expenses = expenses.OrderBy(e => e.Date).ToList();
            }
            else
            {
                expenses = expenses.OrderByDescending(e => e.Date).ToList();
            }

            _logger.LogInformation("Expenses sorted by date");

            return expenses;
        }

        /// <inheritdoc />
        public void RemoveExpense(Expense expense)
        {
            _logger.LogInformation("Removing expense with ID {id}", expense.Id);

            // Vérifier si la dépense est null
            if (expense == null)
            {
                _logger.LogError("Expense object is null");
                throw new ArgumentNullException(nameof(expense));
            }

            _expenseRepository.RemoveExpense(expense);

            _logger.LogInformation("Expense removed successfully");
        }
    }
}

