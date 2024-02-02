using financial_management_api.Api.Models;
using financial_management_api.Api.Repositories.Interfaces;

namespace financial_management_api.Services
{
    public class BudgetService : ICrudService<Budget>
    {
        private readonly IBudgetRepository _budgetRepository;

        public BudgetService(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        public IEnumerable<Budget> GetAll()
        {
            return _budgetRepository.GetAll();
        }

        public Budget GetById(Guid id)
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

        public void Delete(Guid id)
        {
            _budgetRepository.Delete(id);
        }
    }
}
