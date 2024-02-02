using financial_management_api.Api.DataAccess;
using financial_management_api.Api.Models;
using financial_management_api.Api.Repositories.Interfaces;

namespace financial_management_api.Api.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDataAccess _dataAccess;

        public AccountRepository(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<Account> GetAll()
        {
            return _dataAccess.GetAll<Account>();
        }

        public Account GetById(Guid id)
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

        public void Delete(Guid id)
        {
            _dataAccess.Delete<Account>(id);
        }
    }
}