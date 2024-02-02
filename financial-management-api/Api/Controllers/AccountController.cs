using Microsoft.AspNetCore.Mvc;
using financial_management_api.Api.Models;
using financial_management_api.Services;
using System;
using System.Collections.Generic;

namespace financial_management_api.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ICrudService<Account> _accountService;

        public AccountController(ICrudService<Account> accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Account>> GetAll()
        {
            try
            {
                var accounts = _accountService.GetAll();
                return Ok(accounts);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Account> GetById(Guid id)
        {
            try
            {
                var account = _accountService.GetById(id);
                if (account == null)
                {
                    return NotFound($"Account with ID {id} not found");
                }

                return Ok(account);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult<Account> Create(Account account)
        {
            try
            {
                _accountService.Create(account);
                return CreatedAtAction(nameof(GetById), new { id = account.Id }, account);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Account> Update(Guid id, Account account)
        {
            try
            {
                if (id != account.Id)
                {
                    return BadRequest("ID in the request body does not match the route parameter");
                }

                _accountService.Update(account);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Account> Delete(Guid id)
        {
            try
            {
                var existingAccount = _accountService.GetById(id);
                if (existingAccount == null)
                {
                    return NotFound($"Account with ID {id} not found");
                }

                _accountService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
