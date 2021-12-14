using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _supplierService.GetList();

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("Tedarikçiler Listelenemedi");
            }
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _supplierService.GetById(id);

            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Supplier supplier)
        {
            _supplierService.Add(supplier);
            return Ok();
        }

        [HttpPut("put")]
        public IActionResult Update(Supplier supplier)
        {
            _supplierService.Update(supplier);
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var supplier = _supplierService.GetById(id);
            if (supplier != null)
            {
                _supplierService.Delete(id);
                return Ok(supplier);
            }
            else
            {
                return NotFound("Tedarikçi Silinemedi");
            }
        }
    }
}
