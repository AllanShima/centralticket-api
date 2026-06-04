using CentralTicket.Contexts.Auth.Dtos;
using CentralTicket.Contexts.Auth.Entities;
using CentralTicket.Contexts.Auth.Interfaces.IUseCases;

namespace CentralTicket.Contexts.Auth.UseCases
{
    public class CreateTokenResponseUseCase : ICreateTokenResponseUseCase
    {
        private readonly ICreateTokenUseCase _createTokenUseCase;
        private readonly IGenerateAndSaveRefreshTokenUseCase _generateAndSaveRefreshTokenUseCase;
        public CreateTokenResponseUseCase(ICreateTokenUseCase createTokenUseCase, IGenerateAndSaveRefreshTokenUseCase generateAndSaveRefreshTokenUseCase)
        {
            _createTokenUseCase = createTokenUseCase;
            _generateAndSaveRefreshTokenUseCase = generateAndSaveRefreshTokenUseCase;
        }
        public async Task<TokenResponseDto> Run(User user)
        {
            return new TokenResponseDto
            {
                AccessToken = _createTokenUseCase.Run(user),
                RefreshToken = await _generateAndSaveRefreshTokenUseCase.Run(user)
            };
        }
    }
}
