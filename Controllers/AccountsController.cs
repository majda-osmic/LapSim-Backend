using LapSimBackend.Models;
using LapSimBackend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LapSimBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly AccountsService _accountsService;

        public AccountsController(AccountsService accountsService)
        {
            _accountsService = accountsService;
        }

        [HttpGet]
        public ActionResult<List<Account>> Get() =>
            _accountsService.Get();

        [HttpGet("{id:length(24)}", Name = "GetAccount")]
        public ActionResult<Account> Get(string id)
        {
            var account = _accountsService.Get(id);

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }

        [HttpPost]
        public ActionResult<Account> Create(Account account)
        {
            _accountsService.Create(account);

            //Calls CreatedAtRoute in the Create action method to return an HTTP 201 response.
            //Status code 201 is the standard response for an HTTP POST method that creates a new resource on the server.
            //CreatedAtRoute also adds a Location header to the response.
            //The Location header specifies the URI of the newly created book.
            return CreatedAtRoute("GetAccount", new { id = account.Id.ToString() }, account);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Account accountIn)
        {
            var account = _accountsService.Get(id);

            if (account == null)
            {
                return NotFound();
            }

            _accountsService.Update(id, accountIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var account = _accountsService.Get(id);

            if (account == null)
            {
                return NotFound();
            }

            _accountsService.Remove(account.Id);

            return NoContent();
        }
    }
}

