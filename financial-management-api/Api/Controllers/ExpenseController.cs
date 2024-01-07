using financial_management_api.Api.Models;
using financial_management_api.Api.Repositories.Interfaces;
using financial_management_api.Api.Repositories;
using financial_management_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace financial_management_api.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly ExpenseService _expenseService;
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseController()
        {
            _expenseService = new ExpenseService(_expenseRepository);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Expense>> Get()
        {
            return Ok(_expenseService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Expense> Delete(int id)
        {
            var budget = _expenseService.GetById(id);
            if (budget == null)
            {
                return NotFound();
            }

            _expenseService.Delete(id);
            return NoContent();
        }
    }
}