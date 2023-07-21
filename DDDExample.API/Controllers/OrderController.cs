using DDDExample.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDDExample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderService _orderService;
        IHttpContextAccessor httpContextAccessor;
        public OrderController(IOrderService orderService, IHttpContextAccessor httpContextAccessor)
        {
            _orderService = orderService;
            this.httpContextAccessor = httpContextAccessor;
        }
        [HttpGet("getMyOrders")]
        public IActionResult Get()
        {
            var userId = Guid.Parse(httpContextAccessor.HttpContext.User.FindFirst("id")?.Value);
            var result = _orderService.GetMyOrders(userId);
            return Ok(result);
        }
    }
}
