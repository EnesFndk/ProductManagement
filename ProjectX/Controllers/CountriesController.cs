using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _countryService.GetList();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("Ülkeler Bulunamadı");
            }
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _countryService.GetById(id);
            return Ok(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Country country)
        {
            _countryService.Add(country);
            return Ok();
        }
        [HttpPut("update")]
        public IActionResult Update(Country country)
        {
            _countryService.Update(country);
            return Ok();
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var country = _countryService.GetById(id);
            if (country != null)
            {
                _countryService.Delete(id);
                return Ok(country);
            }
            else
            {
                return NotFound("Ülke Silinemedi");
            }

        }
    }
}
