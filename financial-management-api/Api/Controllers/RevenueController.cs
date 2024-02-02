using financial_management_api.Api.Models;
using financial_management_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace financial_management_api.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class RevenueController : ControllerBase
    {
        private readonly ICrudService<Revenue> _revenueService;

        public RevenueController(ICrudService<Revenue> revenueService)
        {
            _revenueService = revenueService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Revenue>> Get()
        {
            return Ok(_revenueService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Revenue> Get(Guid id)
        {
            var revenue = _revenueService.GetById(id);
            if (revenue == null)
            {
                return NotFound();
            }

            return Ok(revenue);
        }

        [HttpPost]
        public ActionResult<Revenue> Create(Revenue revenue)
        {
            _revenueService.Create(revenue);
            return CreatedAtAction(nameof(Get), new { id = revenue.Id }, revenue);
        }

        [HttpPut("{id}")]
        public ActionResult<Revenue> Update(Guid id, Revenue revenue)
        {
            if (id != revenue.Id)
            {
                return BadRequest();
            }

            _revenueService.Update(revenue);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Revenue> Delete(Guid id)
        {
            var revenue = _revenueService.GetById(id);
            if (revenue == null)
            {
                return NotFound();
            }

            _revenueService.Delete(id);
            return NoContent();
        }
    }
}