using API.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            this._addressService = addressService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]string cep)
        {
            return Ok(await _addressService.GetAddressByCep(cep));
        }
    }
}
