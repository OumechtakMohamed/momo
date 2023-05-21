using ExpenseApp.Models;
using ExpenseApp.Repositories;
using ExpenseApp.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace ExpenseApp.Test
{
    public class ExpenseServiceTests
    {
        [Fact]
        public void AddExpense_FutureDate_ThrowsException()
        {
            // Arrange
            var expenseRepositoryMock = new Mock<IExpenseRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var loggerMock = new Mock<ILogger<ExpenseService>>();

            var expenseService = new ExpenseService(expenseRepositoryMock.Object, userRepositoryMock.Object, loggerMock.Object);

            var expense = new Expense
            {
                Date = DateTime.Now.AddDays(1)
            };

            // Act
            Action act = () => expenseService.AddExpense(expense);

            // Assert
            var exception = Assert.Throws<Exception>(act);
            Assert.Equal("La date de la dépense ne peut pas être dans le futur.", exception.Message);
        }

        [Fact]
        public void AddExpense_InvalidDate_ThrowsException()
        {
            // Arrange
            var expenseRepositoryMock = new Mock<IExpenseRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var loggerMock = new Mock<ILogger<ExpenseService>>();

            var expenseService = new ExpenseService(expenseRepositoryMock.Object, userRepositoryMock.Object, loggerMock.Object);

            var expense = new Expense
            {
                Date = DateTime.Now.AddMonths(-4)
            };

            // Act
            Action act = () => expenseService.AddExpense(expense);

            // Assert
            var exception = Assert.Throws<Exception>(act);
            Assert.Equal("La dépense ne peut pas être datée de plus de 3 mois.", exception.Message);
        }

        [Fact]
        public void AddExpense_MissingComment_ThrowsException()
        {
            // Arrange
            var expenseRepositoryMock = new Mock<IExpenseRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var loggerMock = new Mock<ILogger<ExpenseService>>();

            var expenseService = new ExpenseService(expenseRepositoryMock.Object, userRepositoryMock.Object, loggerMock.Object);

            var expense = new Expense
            {
                Comment = "",
                Date = DateTime.Now.AddDays(-3)
            };

            // Act
            Action act = () => expenseService.AddExpense(expense);

            // Assert
            var exception = Assert.Throws<Exception>(act);
            Assert.Equal("Le commentaire est obligatoire pour la dépense.", exception.Message);
        }

        [Fact]
        public void AddExpense_DuplicateExpense_ThrowsException()
        {
            // Arrange
            var expenseRepositoryMock = new Mock<IExpenseRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var loggerMock = new Mock<ILogger<ExpenseService>>();

            var user = new User
            {
                Id = 1,
                Currency = "USD",
            };

            userRepositoryMock.Setup(r => r.GetUserById(It.IsAny<int>()))
                .Returns(user);

            var expenseService = new ExpenseService(expenseRepositoryMock.Object, userRepositoryMock.Object, loggerMock.Object);

            var expense = new Expense
            {
                Date = DateTime.Now,
                Amount = 50,
                User = user,
                Currency = "USD",
                Comment = "ici commentaire"
            };

            expenseRepositoryMock.Setup(r => r.IsExpenseUnique(expense.Date, expense.Amount, expense.UserId))
                .Returns(false);

            // Act
            Action act = () => expenseService.AddExpense(expense);

            // Assert
            var exception = Assert.Throws<Exception>(act);
            Assert.Equal("Un utilisateur ne peut pas déclarer deux fois la même dépense.", exception.Message);
        }

        [Fact]
        public void AddExpense_InvalidCurrency_ThrowsException()
        {
            // Arrange
            var expenseRepositoryMock = new Mock<IExpenseRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var loggerMock = new Mock<ILogger<ExpenseService>>();

            var expenseService = new ExpenseService(expenseRepositoryMock.Object, userRepositoryMock.Object, loggerMock.Object);

            var user = new User
            {
                Currency = "USD",
            };

            userRepositoryMock.Setup(r => r.GetUserById(It.IsAny<int>()))
                .Returns(user);

            var expense = new Expense
            {
                User = user,
                Currency = "EUR",
                Date = DateTime.Now.AddDays(-5),
                Comment = "ici commentaire"
            };

            // Act
            Action act = () => expenseService.AddExpense(expense);

            // Assert
            var exception = Assert.Throws<Exception>(act);
            Assert.Equal("La devise de la dépense doit être identique à celle de l'utilisateur.", exception.Message);
        }

        [Fact]
        public void AddExpense_ValidExpense_NoExceptionThrown()
        {
            // Arrange
            var expenseRepositoryMock = new Mock<IExpenseRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var loggerMock = new Mock<ILogger<ExpenseService>>();

            var expenseService = new ExpenseService(expenseRepositoryMock.Object, userRepositoryMock.Object, loggerMock.Object);

            var user = new User
            {
                Currency = "EUR"
            };

            userRepositoryMock.Setup(r => r.GetUserById(It.IsAny<int>()))
                .Returns(user);

            var expense = new Expense
            {
                UserId = 1,
                Currency = "EUR"
            };

            // Act & Assert
            Assert.Throws<Exception>(() => expenseService.AddExpense(expense));
        }


    }
}
