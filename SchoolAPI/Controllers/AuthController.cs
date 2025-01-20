using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Model;
using SchoolAPI.ModelDTO;
using SchoolAPI.Service;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly StudentDBContext _dbContext;

        public AuthController(IAuthService authService, StudentDBContext dbContext)
        {
            _authService = authService;
            _dbContext = dbContext;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO login)
        {
            if (_authService.ValidateUser(login.Username, login.Password))
            {
                var token = _authService.GenerateToken(login.Username);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDTO register)
        {
            _authService.RegisterUser(register.Username, register.Password, register.Email);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
