using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetList();

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("Kategoriler Listelenemedi");
            }
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _categoryService.GetById(id);

            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Category category)
        {
            _categoryService.Add(category);
            return Ok();
        }

        [HttpPut("put")]
        public IActionResult Update(Category category)
        {
            _categoryService.Update(category);
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetById(id);
            if (category != null)
            {
                _categoryService.Delete(id);
                return Ok(category);
            }
            else
            {
                return NotFound("Kategori Silinemedi");
            }
        }
    }
}
