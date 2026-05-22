using Microsoft.AspNetCore.Mvc;

namespace CentralTicket.Contexts.Auth.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly TokenGenerator _tokenGenerator;

        public AuthController(TokenGenerator tokenGenerator)
        {
            this._tokenGenerator = tokenGenerator;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Implementation for login logic
            var token = _tokenGenerator.GenerateToken(request.Email.Value);
            return Ok(token);
        }

    }
}
