using financial_management_api.Api.Extensions;
using financial_management_api.Api.Models;
using financial_management_api.Api.Repositories.Interfaces;

namespace financial_management_api.Services
{
    public class ExpenseService : ICrudService<Expense>
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public IEnumerable<Expense> GetAll()
        {
            return _expenseRepository.GetAll();
        }

        public Expense GetById(Guid id)
        {
            return _expenseRepository.GetById(id);
        }

        public void Create(Expense entity)
        {
            _expenseRepository.Create(entity);
        }

        public void CreateExpense(Expense expense)
        {
            if (!expense.CurrencyCode.IsValidCurrencyCode())
            {
                // Handle invalid currency code, perhaps log and throw an exception
                //Log.Error($"Invalid currency code: {expense.CurrencyCode}");
                throw new InvalidCurrencyCodeException($"Invalid currency code: {expense.CurrencyCode}");
            }

            // Continue creating the expense
            _expenseRepository.Create(expense);
        }

        public void Update(Expense entity)
        {
            _expenseRepository.Update(entity);
        }

        public void Delete(Guid id)
        {
            _expenseRepository.Delete(id);
        }
    }
}
