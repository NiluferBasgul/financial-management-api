using financial_management_api.Api.Models;
using financial_management_api.Api.Repositories;
using financial_management_api.Api.Repositories.Interfaces;

namespace financial_management_api.Services
{
    public class BudgetService : ICrudService<Budget>
    {
        private readonly IBudgetRepository _budgetRepository;
        private readonly EmailSender _emailSender;
        private BudgetRepository? budgetRepository;

        public BudgetService(BudgetRepository budgetRepository, EmailSender emailSender)
        {
            _budgetRepository = budgetRepository;
            _emailSender = emailSender;
        }

        public BudgetService(BudgetRepository? budgetRepository)
        {
            this.budgetRepository = budgetRepository;
        }

        public IEnumerable<Budget> GetAll()
        {
            return _budgetRepository.GetAll();
        }

        public Budget GetById(int id)
        {
            return _budgetRepository.GetById(id);
        }

        public void Create(Budget entity)
        {
            _budgetRepository.Create(entity);
        }

        public void Update(Budget entity)
        {
            _budgetRepository.Update(entity);
        }

        public void Delete(int id)
        {
            _budgetRepository.Delete(id);
        }
    }
}
