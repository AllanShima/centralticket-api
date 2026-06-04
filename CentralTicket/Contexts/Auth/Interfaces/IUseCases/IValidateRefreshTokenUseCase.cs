using CentralTicket.Contexts.Auth.Entities;

namespace CentralTicket.Contexts.Auth.Interfaces.IUseCases
{
    public interface IValidateRefreshTokenUseCase
    {
        public Task<User?> Run(Guid userId, string refreshToken);
    }
}
