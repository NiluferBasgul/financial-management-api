using financial_management_api.Api.Data;
using financial_management_api.Api.DataAccess;
using financial_management_api.Api.Models;
using financial_management_api.Api.Repositories.Interfaces;

namespace financial_management_api.Api.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly IDataAccess _dataAccess;

        public ExpenseRepository(ApplicationDbContext context)
        {
            _dataAccess = new DataAccess.DataAccess(context);
        }

        public void Create(Expense entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Expense> GetAll()
        {
            throw new NotImplementedException();
        }

        public Expense GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Expense entity)
        {
            throw new NotImplementedException();
        }
    }
}
