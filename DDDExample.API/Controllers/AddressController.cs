using DDDExample.Application.Interfaces;
using DDDExample.domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDDExample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        IAddressService _addressService;
        IHttpContextAccessor httpContextAccessor;

        public AddressController(IAddressService addressService, IHttpContextAccessor httpContextAccessor = null, IUserService userService = null)
        {
            _addressService = addressService;
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_addressService.GetAddresses());
        }
        [HttpGet("GetMyAddresses")]
        public IActionResult GetByAddresses()
        {
            var userId = Guid.Parse(httpContextAccessor.HttpContext.User.FindFirst("id")?.Value);
            var result = _addressService.GetUserAdress(userId);
            return Ok(result);
        }
        [Authorize]
        [HttpPost("AddAddress")]
        public IActionResult AddAddress(Address address)
        {
            address.UserId = Guid.Parse(httpContextAccessor.HttpContext.User.FindFirst("id")?.Value);
            
            var result = _addressService.AddAdress(address);
            if (result)
            {
                return Ok("Başarılı bir şekilde address eklendi");
            }
            return Ok("en fazla 3 address ekleyebilirsin");
        }
    }
}
