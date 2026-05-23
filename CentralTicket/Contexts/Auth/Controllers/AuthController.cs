using CentralTicket.Contexts.Auth.Entities;
using CentralTicket.Contexts.Auth.Requests;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CentralTicket.Contexts.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenGenerator _tokenGenerator;

        public AuthController(TokenGenerator tokenGenerator)
        {
            this._tokenGenerator = tokenGenerator;
        }

        private static User user = new();

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            var hashedPassword = new PasswordHasher<User>()
                .HashPassword(user, request.Password.Value);

            user.Email = request.Email;
            user.PasswordHash = hashedPassword;

            return Ok(user);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Implementation for login logic
            if (user.Email != request.Email)
            {
                return BadRequest("Email não encontrado");
            }
            if(new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, request.Password.Value) == PasswordVerificationResult.Failed)
            {
                return BadRequest("Senha incorreta");
            }

            //var token = _tokenGenerator.GenerateToken(request.Email.Value);
            var token = "success";
            return Ok(token);
        }

    }
}
