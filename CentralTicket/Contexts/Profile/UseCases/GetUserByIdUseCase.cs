using CentralTicket.Contexts.Profile.DTOs.User;
using CentralTicket.Contexts.Profile.Entities;
using CentralTicket.Contexts.Profile.Interfaces.IRepositories;
using CentralTicket.Contexts.Profile.Interfaces.IUseCases;

namespace CentralTicket.Contexts.Profile.UseCases
{
    public class GetUserByIdUseCase : IGetUserByIdUseCase
    {
        private readonly Contexts.Auth.Interfaces.IRepositories.IUserRepository _authUserRepository;
        public GetUserByIdUseCase(Contexts.Auth.Interfaces.IRepositories.IUserRepository authUserRepository)
        {
            _authUserRepository = authUserRepository;
        }

        public ReadUserDTO Run(Guid id)
        {
            var user = this._authUserRepository.GetById(id);
             

            if (user == null) throw new Exception("Usuário não encontrado");
            
            return new ReadUserDTO
            {
                Id = user.Id,
                Name = new ValueObjects.Name(user.Name.Value),
                Email = new ValueObjects.Email(user.Email.Value),
                ProfilePictureUrl = user.ProfilePictureUrl,
                CreatedAt = user.CreatedAt
            };
        }
    }
}
