using ExpenseApp.Models;
using ExpenseApp.Services;
using ExpenseApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseService _expenseService;
        private readonly IUserService _userService;

        public ExpensesController(IExpenseService expenseService, IUserService userService)
        {
            _expenseService = expenseService;
            _userService = userService;
        }

        /// <summary>
        /// Récupère la liste de toutes les dépenses.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(List<Expense>), 200)]
        public IActionResult GetAllExpenses()
        {
            List<Expense> expenses = _expenseService.GetAllExpenses();
            return Ok(expenses);
        }

        /// <summary>
        /// Récupère la liste des dépenses pour un utilisateur donné.
        /// </summary>
        /// <param name="userId">Identifiant de l'utilisateur.</param>
        [HttpGet("user/{userId}")]
        [ProducesResponseType(typeof(List<Expense>), 200)]
        public IActionResult GetExpensesByUserId(int userId)
        {
            List<Expense> expenses = _expenseService.GetExpensesByUserId(userId);
            return Ok(expenses);
        }

        /// <summary>
        /// Récupère la liste des dépenses triées par montant.
        /// </summary>
        /// <param name="ascending">Indique si le tri est ascendant (true) ou descendant (false).</param>
        [HttpGet("sorted-by-amount")]
        [ProducesResponseType(typeof(List<Expense>), 200)]
        public IActionResult GetExpensesSortedByAmount(bool ascending = true)
        {
            List<Expense> expenses = _expenseService.SortExpensesByAmount(ascending);
            return Ok(expenses);
        }

        /// <summary>
        /// Récupère la liste des dépenses triées par date.
        /// </summary>
        /// <param name="ascending">Indique si le tri est ascendant (true) ou descendant (false).</param>
        [HttpGet("sorted-by-date")]
        [ProducesResponseType(typeof(List<Expense>), 200)]
        public IActionResult GetExpensesSortedByDate(bool ascending = true)
        {
            List<Expense> expenses = _expenseService.SortExpensesByDate(ascending);
            return Ok(expenses);
        }

        /// <summary>
        /// Ajoute une nouvelle dépense.
        /// </summary>
        /// <param name="expenseViewModel">Les informations de la dépense à ajouter.</param>
        [HttpPost]
        [ProducesResponseType(typeof(Expense), 201)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult AddExpense([FromBody] ExpenseCreateViewModel expenseViewModel)
        {
            try
            {
                User user = _userService.GetUserById(expenseViewModel.UserId);

                if (user == null)
                    return NotFound("L'utilisateur associé à la dépense n'existe pas.");

                var expense = new Expense
                {
                    User = user,
                    Date = expenseViewModel.Date,
                    Nature = expenseViewModel.Nature,
                    Amount = expenseViewModel.Amount,
                    Currency = expenseViewModel.Currency,
                    Comment = expenseViewModel.Comment
                };

                _expenseService.AddExpense(expense);
                return CreatedAtAction(nameof(GetExpense), new
                {
                    id = expense.Id
                }, expense);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Récupère une dépense par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant de la dépense.</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ExpenseViewModel), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetExpense(int id)
        {
            Expense expense = _expenseService.GetExpenseById(id);

            if (expense == null)
            {
                return NotFound();
            }

            // Récupérer l'utilisateur associé à la dépense
            User user = _userService.GetUserById(expense.UserId);

            if (user == null)
            {
                return NotFound("L'utilisateur associé à la dépense n'existe pas.");
            }

            // Créer un ViewModel pour retourner toutes les propriétés de la dépense
            ExpenseViewModel expenseViewModel = new ExpenseViewModel
            {
                Id = expense.Id,
                User = $"{user.FirstName} {user.LastName}",
                Date = expense.Date,
                Nature = expense.Nature,
                Amount = expense.Amount,
                Currency = expense.Currency,
                Comment = expense.Comment
            };

            return Ok(expenseViewModel);
        }
    }
}

