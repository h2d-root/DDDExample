using DDDExample.Application.DTO;
using DDDExample.Application.Interfaces;
using DDDExample.domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace DDDExample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService _productService;
        IHttpContextAccessor httpContextAccessor;


        public ProductController(IProductService productService, IHttpContextAccessor httpContextAccessor )
        {
            _productService = productService;
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("ProductName")]
        public IActionResult ProductSearch(string name)
        {
            var result = _productService.GetByProductName(name);
            return Ok(result);
        }
        [HttpGet]
        public IActionResult GetAllProduct()
        {
            var result = _productService.GetProducts();
            return Ok(result);
        }

        [HttpPost("AddProduct")]
        public IActionResult ProductAdd(Product product)
        {
            var userId = Guid.Parse(httpContextAccessor.HttpContext.User.FindFirst("id")?.Value);
            product.UserId = userId;
            if (_productService.AddProduct(product))
            {
                return Ok("ürün eklendi");
            }
            return Ok("ürün eklenemedi");
        }
        [HttpPost("GetByCategory")]
        public IActionResult GetProduct(Guid categoryId)
        {
            var result = _productService.GetByCategoryProduct(categoryId);
            return Ok(result);
        }
        [HttpPost("GetByFilter")]
        public IActionResult GetFilterProduct(ProductFilterDTO dTO)
        {
            var result = _productService.GetByFilterProduct(dTO);
            return Ok(result);
        }

    }
}
