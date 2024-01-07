using financial_management_api.Api.Data;
using financial_management_api.Api.DataAccess;
using financial_management_api.Api.Models;
using financial_management_api.Api.Repositories.Interfaces;

namespace financial_management_api.Api.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        // Here, you would inject an IDataAccess object instead of creating a new instance directly.
        // For simplicity, I'm creating a new instance in the constructor.
        private readonly IDataAccess _dataAccess;

        public AccountRepository(ApplicationDbContext context)
        {
            _dataAccess = new DataAccess.DataAccess(context);
        }

        public IEnumerable<Account> GetAll()
        {
            return _dataAccess.GetAll<Account>();
        }

        public Account GetById(int id)
        {
            return _dataAccess.GetById<Account>(id);
        }

        public void Create(Account entity)
        {
            _dataAccess.Create(entity);
        }

        public void Update(Account entity)
        {
            _dataAccess.Update(entity);
        }

        public void Delete(int id)
        {
            _dataAccess.Delete<Account>(id);
        }
    }
}
