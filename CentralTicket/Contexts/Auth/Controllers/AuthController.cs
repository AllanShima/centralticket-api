using CentralTicket.Contexts.Auth.Entities;
using CentralTicket.Contexts.Auth.Requests;
using CentralTicket.Contexts.Auth.UseCases;
using CentralTicket.Contexts.Billing.Interfaces.IUseCases;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CentralTicket.Contexts.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly RegisterUseCase _registerUseCase;
        private readonly LoginUseCase _loginUseCase;
        public AuthController(
            RegisterUseCase registerUseCase,
            LoginUseCase loginUseCase)
        {
            this._registerUseCase = registerUseCase;
            this._loginUseCase = loginUseCase;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            var user = _registerUseCase.Run(request);

            if (user == null)
            {
                return BadRequest("Usuário já cadastrado");
            }

            return Ok(user);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var token = _loginUseCase.Run(request);
            
            if (token == null)
            {
                return BadRequest("Credenciais inválidas");
            }

            return Ok(token);
        }

    }
}
