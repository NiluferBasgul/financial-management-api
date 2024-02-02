using financial_management_api.Api.Models;
using financial_management_api.Api.Repositories.Interfaces;

namespace financial_management_api.Services
{
    public class AccountService : ICrudService<Account>
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IEnumerable<Account> GetAll()
        {
            return _accountRepository.GetAll();
        }

        public Account GetById(Guid id)
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

        public void Delete(Guid id)
        {
            _accountRepository.Delete(id);
        }

    }
}
