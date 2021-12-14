using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userService.GetList();

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("Kullanıcılar Listelenemedi");
            }
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetById(id);

            return Ok(result);
        }
        [HttpGet("getemail")]
        public IActionResult GetByEmail(string email)
        {
            var result = _userService.GetByMail(email);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("Kullanıcı Maili Bulunamadı");
            }
        }

        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            _userService.Add(user);
            return Ok();
        }

        [HttpPut("put")]
        public IActionResult Update(User user)
        {
            _userService.Update(user);
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var user = _userService.GetById(id);
            if (user != null)
            {
                _userService.Delete(id);
                return Ok(user);
            }
            else
            {
                return NotFound("Kullanıcı Silinemedi");
            }
        }
    }
}
