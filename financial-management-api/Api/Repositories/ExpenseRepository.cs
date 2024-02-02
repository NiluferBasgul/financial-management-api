using financial_management_api.Api.DataAccess;
using financial_management_api.Api.Models;
using financial_management_api.Api.Repositories.Interfaces;

namespace financial_management_api.Api.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly IDataAccess _dataAccess;

        public ExpenseRepository(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<Expense> GetAll()
        {
            return _dataAccess.GetAll<Expense>();
        }

        public Expense GetById(Guid id)
        {
            return _dataAccess.GetById<Expense>(id);
        }

        public void Create(Expense entity)
        {
            _dataAccess.Create(entity);
        }

        public void Update(Expense entity)
        {
            _dataAccess.Update(entity);
        }

        public void Delete(Guid id)
        {
            _dataAccess.Delete<Expense>(id);
        }
    }
}