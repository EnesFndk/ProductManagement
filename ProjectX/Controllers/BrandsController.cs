using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Business.Abstract;
using Business;

namespace ProjectX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _brandService.GetList();

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("Marka Listelenemedi");
            }
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _brandService.GetById(id);

            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Brand brand)
        {
            _brandService.Add(brand);
            return Ok();
        }

        [HttpPut("put")]
        public IActionResult Update(Brand brand)
        {
            _brandService.Update(brand);
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var brand = _brandService.GetById(id);
            if (brand != null)
            {
                _brandService.Delete(id);
                return Ok(brand);
            }
            else
            {
                return NotFound("Marka Silinemedi");
            }
        }

        
    }
}
