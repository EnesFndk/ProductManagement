using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _cityService.GetList();

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("Şehirler Listelenemedi");
            }
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _cityService.GetById(id);

            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(City city)
        {
            _cityService.Add(city);
            return Ok();
        }

        [HttpPut("put")]
        public IActionResult Update(City city)
        {
            _cityService.Update(city);
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var city = _cityService.GetById(id);
            if (city != null)
            {
                _cityService.Delete(id);
                return Ok(city);
            }
            else
            {
                return NotFound("Şehir Silinemedi");
            }
        }
    }
}
