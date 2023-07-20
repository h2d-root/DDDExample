using DDDExample.Application.Interfaces;
using DDDExample.domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDDExample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [HttpGet("GetAll")]
        public IActionResult AllCategory()
        {
            var result = _categoryService.GetAll();
            return Ok(result);
        }
        [HttpPost("AddCategory")]
        public IActionResult AddCategory(Category category)
        {
            category.Id = Guid.NewGuid();
            var result = _categoryService.Add(category);
            if (result)
            {
                return Ok("yeni kategori eklendi");
            }
            return Ok("hata lan");
        }

        [HttpPost("UpdateCategory")]
        public IActionResult UptadeCategory(Category category)
        {
            var result = _categoryService.Update(category);
            if (result)
            {
                return Ok("kategori güncellendi");
            }
            return Ok("hata lan");
        }
        
        [HttpPost("DeleteCategory")]
        public IActionResult DeleteCategory(Category category)
        {
            var result = _categoryService.Delete(category);
            if (result)
            {
                return Ok("kategori silindi");
            }
            return Ok("hata lan");
        }

    }
}
