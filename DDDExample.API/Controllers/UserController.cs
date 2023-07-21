using DDDExample.Application.DTO;
using DDDExample.Application.Interfaces;
using DDDExample.domain.Entity;
using DDDExample.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DDDExample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        private readonly IConfiguration _configuration;
        IHttpContextAccessor httpContextAccessor;
        JwtHelper jwtHelper = new JwtHelper();


        public UserController(IConfiguration configuration, IUserService userService, IHttpContextAccessor httpContextAccessor = null)
        {
            _configuration = configuration;
            _userService = userService;
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("EditProfile")]
        public IActionResult EditProfile(EditUser editUser)
        {
            var userId = Guid.Parse(httpContextAccessor.HttpContext.User.FindFirst("id")?.Value);
            var result = _userService.EditUser(editUser, userId);
            if (result)
            {
                return Ok("başarılı bir şekilde güncellendi");
            }
            return Ok("hatalı işlem");
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
            var user = _userService.Login(login);
            if (user == null)
            {
                return Ok("bilgilerinizi kontrol ediniz");
            }

            // Kullanıcı başarıyla giriş yaptıysa, JWT oluşturun.
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var token = jwtHelper.GenerateJwtToken(user, jwtSettings);

            // Token'ı istemciye gönderin veya dilediğiniz şekilde kullanın.
            return Ok(new { Token = token });
        }

        

        [Authorize]
        [HttpGet("UserInfo")]
        public IActionResult UserInfo()
        {
            var userId = Guid.Parse(httpContextAccessor.HttpContext.User.FindFirst("id")?.Value);

            var user = _userService.UserInfo(userId);
                    
            return Ok(user);
        }


        [HttpPost("AllUser")]
        public IActionResult AllUser()
        {
            return Ok(_userService.GetUsers());
        }
    }
}
