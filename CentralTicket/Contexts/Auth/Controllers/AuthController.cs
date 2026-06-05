using CentralTicket.Contexts.Auth.Dtos;
using CentralTicket.Contexts.Auth.Interfaces.IUseCases;
using CentralTicket.Contexts.Auth.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CentralTicket.Contexts.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IRegisterUseCase _registerUseCase;
        private readonly ILoginUseCase _loginUseCase;
        private readonly IRefreshTokensUseCase _refreshTokensUseCase;
        public AuthController(
            IRegisterUseCase registerUseCase,
            ILoginUseCase loginUseCase,
            IRefreshTokensUseCase refreshTokensUseCase)
        {
            this._registerUseCase = registerUseCase;
            this._loginUseCase = loginUseCase;
            this._refreshTokensUseCase = refreshTokensUseCase;
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
        public async Task<ActionResult<TokenResponseDto>> Login([FromBody] LoginRequest request)
        {
            var result = await _loginUseCase.Run(request);
            
            if (result == null)
            {
                return BadRequest("Credenciais inválidas");
            }

            return Ok(result);
        }

        [Authorize]
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("Você conseguiu acessar a rota protegida!");
        }

        [Authorize]
        [HttpGet("me")]
        public IActionResult GetMe()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userName = User.FindFirst(ClaimTypes.Name)?.Value;

            return Ok(new { Id = userId, Name = userName });
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenResponseDto>> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            var result = await _refreshTokensUseCase.Run(request);

            if (result == null || result.AccessToken == null || result.RefreshToken == null || result.RefreshToken == null)
            {
                return Unauthorized("Refresh token inválido");
            }

            return Ok(result);
        }
    }
}
