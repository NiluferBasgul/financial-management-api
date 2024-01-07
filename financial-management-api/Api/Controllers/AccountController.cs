using financial_management_api.Api.Models;
using financial_management_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace financial_management_api.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        // Dependency injection would be used here to get the Account service.
        // For simplicity, I'm creating a new instance in the constructor.
        private readonly AccountService _accountService;

        public AccountController()
        {
            _accountService = new AccountService();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Account>> Get()
        {
            return Ok(_accountService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Account> Get(int id)
        {
            var account = _accountService.GetById(id);
            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }

        [HttpPost]
        public ActionResult<Account> Create(Account account)
        {
            _accountService.Create(account);
            return CreatedAtAction(nameof(Get), new { id = account.Id }, account);
        }

        [HttpPut("{id}")]
        public ActionResult<Account> Update(Guid id, Account account)
        {
            if (id != account.Id)
            {
                return BadRequest();
            }

            _accountService.Update(account);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Account> Delete(int id)
        {
            var account = _accountService.GetById(id);
            if (account == null)
            {
                return NotFound();
            }

            _accountService.Delete(id);
            return NoContent();
        }
    }
}
