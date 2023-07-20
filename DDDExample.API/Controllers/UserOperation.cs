using DDDExample.Application.DTO;
using DDDExample.Application.Interfaces;
using DDDExample.domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDDExample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperation : ControllerBase
    {
        IUserService _userService;

        public UserOperation(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public IActionResult RegisterUser(User user)
        {
            user.Id = Guid.NewGuid();
            if (_userService.Register(user))
            {
                return Ok("Başarı ile kayıt olundu!");
            }
            return Ok("bu mail hesabı ile daha önce hesap oluşturulmuştur!");
        }

        [HttpPost("Login")]
        public IActionResult LoginUser(LoginDTO login)
        {
            if (_userService.Login(login) == null)
            {
                return Ok("bilgilerinizi kontrol ediniz");
            }


            return Ok();
        }
    }
}
