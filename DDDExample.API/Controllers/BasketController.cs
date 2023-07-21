using DDDExample.Application.DTO;
using DDDExample.Application.Interfaces;
using DDDExample.domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDDExample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        IBasketService _basketService;
        IHttpContextAccessor httpContextAccessor;

        public BasketController(IBasketService basketService, IHttpContextAccessor httpContextAccessor)
        {
            _basketService = basketService;
            this.httpContextAccessor = httpContextAccessor;
        }
        [HttpGet("MyBaskets")]
        public IActionResult GetMyBaskets()
        {
            var userId = Guid.Parse(httpContextAccessor.HttpContext.User.FindFirst("id")?.Value);
            var result = _basketService.GetAll(userId);
            return Ok(result);
        }

        [HttpPost("AddMyBasket")]
        public IActionResult AddMyBaskets(BasketDto dto)
        {
            var userId = Guid.Parse(httpContextAccessor.HttpContext.User.FindFirst("id")?.Value);
            dto.UserId = userId;
            if (_basketService.AddProduct(dto))
            {
                return Ok("Ürün Eklendi");
            }
            return Ok("ürün eklenemedi");
        }
        [HttpPost("buyMyBasket")]
        public IActionResult BuyMyBaskets(Basket basket)
        {
            var userId = Guid.Parse(httpContextAccessor.HttpContext.User.FindFirst("id")?.Value);
            basket.UserId = userId;
            if (_basketService.BuyProduct(basket, userId))
            {
                return Ok("Satın alma başarılı");
            }
            return Ok("satın alma başarısız");
        }
        [HttpPost("RemoveMyBasket")]
        public IActionResult RemoveMyBaskets(BasketDto dto)
        {
            var userId = Guid.Parse(httpContextAccessor.HttpContext.User.FindFirst("id")?.Value);
            dto.UserId = userId;
            if (_basketService.RemoveProduct(dto))
            {
                return Ok("Ürün çıkarıldı");
            }
            return Ok("ürün çıkalımadı");
        }
    }
}
