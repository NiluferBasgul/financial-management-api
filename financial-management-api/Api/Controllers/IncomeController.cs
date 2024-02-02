using financial_management_api.Api.Models;
using financial_management_api.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace financial_management_api.Api.Controller
{
    [ApiController]
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    public class IncomeController : ControllerBase
    {
        private readonly ICrudService<Income> _incomeService;

        // Use dependency injection to inject the service.
        public IncomeController(ICrudService<Income> incomeService)
        {
            _incomeService = incomeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Income>> Get()
        {
            return Ok(_incomeService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Income> Get(Guid id)
        {
            var income = _incomeService.GetById(id);
            if (income == null)
            {
                return NotFound();
            }

            return Ok(income);
        }

        [HttpPost]
        public ActionResult<Income> Create(Income income)
        {
            _incomeService.Create(income);
            return CreatedAtAction(nameof(Get), new { id = income.Id }, income);
        }

        [HttpPut("{id}")]
        public ActionResult<Income> Update(Guid id, Income income)
        {
            if (id != income.Id)
            {
                return BadRequest();
            }

            _incomeService.Update(income);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Income> Delete(Guid id)
        {
            var income = _incomeService.GetById(id);
            if (income == null)
            {
                return NotFound();
            }

            _incomeService.Delete(id);
            return NoContent();
        }
    }
}