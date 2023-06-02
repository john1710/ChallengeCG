using API.Data.Account;
using API.Interfaces.Services;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;
        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpGet("{id:long}",Name = "GetAccountById")]
        public async Task<IActionResult> GetById([FromRoute]long id)
        {
            var entity = await _service.GetById(id);
            return Ok(entity);
        }

        [HttpGet(Name = "GetAllAcounts")]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _service.GetAll();
            return Ok(entities);
        }

        [HttpPost(Name = "CreateAccount")]
        [ProducesResponseType(typeof(Account), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody]UpsertAccountInput input)
        {
            var entity = await _service.Create(input);
            return Created(nameof(GetById), new {id = entity.Id});
        }

        [HttpPost("{id:long}", Name = "UpdateAccount")]
        [ProducesResponseType(typeof(Account), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromRoute]long id,[FromBody] UpsertAccountInput input)
        {
            input.Id = id;
            var entity = await _service.Update(input);
            return Ok(entity);
        }

        [HttpDelete("{id:long}", Name = "DeleteAccount")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            await _service.Delete(id);
            return NotFound();
        }
    }
}
