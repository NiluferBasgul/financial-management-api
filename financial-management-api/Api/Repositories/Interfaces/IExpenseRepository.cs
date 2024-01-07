using financial_management_api.Api.Models;
using financial_management_api.Services;

namespace financial_management_api.Api.Repositories.Interfaces
{
    public interface IExpenseRepository : ICrudService<Expense>
    {
    }
}
