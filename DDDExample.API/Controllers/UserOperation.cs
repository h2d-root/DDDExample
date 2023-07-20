using DDDExample.Application.DTO;
using DDDExample.Application.Interfaces;
using DDDExample.domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DDDExample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperation : ControllerBase
    {
        IUserService _userService;
        private readonly IConfiguration _configuration;
        IHttpContextAccessor httpContextAccessor;


        public UserOperation(IConfiguration configuration, IUserService userService, IHttpContextAccessor httpContextAccessor = null)
        {
            _configuration = configuration;
            _userService = userService;
            this.httpContextAccessor = httpContextAccessor;
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
            var token = GenerateJwtToken(user, jwtSettings);

            // Token'ı istemciye gönderin veya dilediğiniz şekilde kullanın.
            return Ok(new { Token = token });
        }

        private string GenerateJwtToken(User user, IConfiguration jwtSettings)
        {
            var secretKey = Encoding.ASCII.GetBytes(jwtSettings["SecretKey"]);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim("id", user.Id.ToString()),
            new Claim("passwd", user.Password),
            new Claim("username", user.UserName),
                    // Dilediğiniz diğer talepleri ekleyebilirsiniz.
                }),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["TokenExpirationMinutes"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
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
