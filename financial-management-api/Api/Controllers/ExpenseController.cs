using financial_management_api.Api.Models;
using financial_management_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace financial_management_api.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly ICrudService<Expense> _expenseService;

        // Use dependency injection to inject the service.
        public ExpenseController(ICrudService<Expense> expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Expense>> Get()
        {
            return Ok(_expenseService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Expense> Get(Guid id)
        {
            var expense = _expenseService.GetById(id);
            if (expense == null)
            {
                return NotFound();
            }

            return Ok(expense);
        }

        [HttpPost]
        public ActionResult<Expense> Create(Expense expense)
        {
            _expenseService.Create(expense);
            return CreatedAtAction(nameof(Get), new { id = expense.Id }, expense);
        }

        [HttpPut("{id}")]
        public ActionResult<Expense> Update(Guid id, Expense expense)
        {
            if (id != expense.Id)
            {
                return BadRequest();
            }

            _expenseService.Update(expense);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Expense> Delete(Guid id)
        {
            var expense = _expenseService.GetById(id);
            if (expense == null)
            {
                return NotFound();
            }

            _expenseService.Delete(id);
            return NoContent();
        }
    }
}