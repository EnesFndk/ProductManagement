using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productService.GetList();

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("Ürünler Listelenemedi");
            }
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);

            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] Product product)
        {
            _productService.Add(product);
            return Ok();
        }

        [HttpPut("put")]
        public IActionResult Update(Product product)
        {
            _productService.Update(product);
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var product = _productService.GetById(id);
            if (product != null)
            {
                _productService.Delete(id);
                return Ok(product);
            }
            else
            {
                return NotFound("Ürün Silinemedi");
            }
        }
    }
}
