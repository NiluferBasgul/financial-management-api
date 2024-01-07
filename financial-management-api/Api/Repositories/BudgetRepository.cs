using financial_management_api.Api.Data;
using financial_management_api.Api.DataAccess;
using financial_management_api.Api.Models;
using financial_management_api.Api.Repositories.Interfaces;

namespace financial_management_api.Api.Repositories
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly IDataAccess _dataAccess;

        public BudgetRepository(ApplicationDbContext context)
        {
            _dataAccess = new DataAccess.DataAccess(context);
        }

        public IEnumerable<Budget> GetAll()
        {
            return _dataAccess.GetAll<Budget>();
        }

        public Budget GetById(int id)
        {
            return _dataAccess.GetById<Budget>(id);
        }

        public void Create(Budget entity)
        {
            _dataAccess.Create(entity);
        }

        public void Update(Budget entity)
        {
            _dataAccess.Update(entity);
        }

        public void Delete(int id)
        {
            _dataAccess.Delete<Budget>(id);
        }
    }
}
