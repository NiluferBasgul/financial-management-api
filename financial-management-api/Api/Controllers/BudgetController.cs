using financial_management_api.Api.Models;
using financial_management_api.Api.Repositories;
using financial_management_api.Api.Repositories.Interfaces;
using financial_management_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace financial_management_api.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BudgetController : ControllerBase
    {
        private readonly BudgetService _budgetService;
        private readonly BudgetRepository _budgetRepository;

        public BudgetController()
        {
            this._budgetService = new BudgetService(_budgetRepository);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Budget>> Get()
        {
            return Ok(_budgetService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Budget> Get(int id)
        {
            var budget = _budgetService.GetById(id);
            if (budget == null)
            {
                return NotFound();
            }

            return Ok(budget);
        }

        [HttpPost]
        public ActionResult<Budget> Create(Budget budget)
        {
            _budgetService.Create(budget);
            return CreatedAtAction(nameof(Get), new { id = budget.Id }, budget);
        }

        [HttpPut("{id}")]
        public ActionResult<Budget> Update(Guid id, Budget budget)
        {
            if (id != budget.Id)
            {
                return BadRequest();
            }

            _budgetService.Update(budget);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Budget> Delete(int id)
        {
            var budget = _budgetService.GetById(id);
            if (budget == null)
            {
                return NotFound();
            }

            _budgetService.Delete(id);
            return NoContent();
        }
    }
}
