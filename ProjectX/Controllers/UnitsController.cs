using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly IUnitService _unitService;

        public UnitsController(IUnitService unitService)
        {
            _unitService = unitService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _unitService.GetList();

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("Birimler Listelenemedi");
            }
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _unitService.GetById(id);

            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Unit unit)
        {
            _unitService.Add(unit);
            return Ok();
        }

        [HttpPut("put")]
        public IActionResult Update(Unit unit)
        {
            _unitService.Update(unit);
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var unit = _unitService.GetById(id);
            if (unit != null)
            {
                _unitService.Delete(id);
                return Ok(unit);
            }
            else
            {
                return NotFound("Birim Silinemedi");
            }
        }
    }
}
