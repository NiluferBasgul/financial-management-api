using financial_management_api.Api.Data;
using financial_management_api.Api.Models;
using financial_management_api.Api.Repositories;
using financial_management_api.Api.Repositories.Interfaces;

namespace financial_management_api.Services
{
    public class AccountService : ICrudService<Account>
    {
        // Here, you would inject an IAccountRepository instead of creating a new instance directly.
        // For simplicity, I'm creating a new instance in the constructor.
        private readonly IAccountRepository _accountRepository;
        private readonly ApplicationDbContext context;

        public AccountService()
        {
            _accountRepository = new AccountRepository(context);
        }

        public IEnumerable<Account> GetAll()
        {
            return _accountRepository.GetAll();
        }

        public Account GetById(int id)
        {
            return _accountRepository.GetById(id);
        }

        public void Create(Account entity)
        {
            _accountRepository.Create(entity);
        }

        public void Update(Account entity)
        {
            _accountRepository.Update(entity);
        }

        public void Delete(int id)
        {
            _accountRepository.Delete(id);
        }
    }
}
