using financial_management_api.Api.Models;
using financial_management_api.Api.Repositories;
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

        public Expense GetById(int id)
        {
            return _expenseRepository.GetById(id);
        }

        public void Create(Expense entity)
        {
            _expenseRepository.Create(entity);
        }

        public void Update(Expense entity)
        {
            _expenseRepository.Update(entity);
        }

        public void Delete(int id)
        {
            _expenseRepository.Delete(id);
        }
    }
}
