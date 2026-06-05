using CentralTicket.Contexts.Auth.Entities;
using CentralTicket.Contexts.Auth.Interfaces.IRepositories;
using CentralTicket.Contexts.Auth.Interfaces.IUseCases;
using CentralTicket.Contexts.Auth.Requests;
using Microsoft.AspNetCore.Identity;

namespace CentralTicket.Contexts.Auth.UseCases
{
    public class RegisterUseCase : IRegisterUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly Contexts.Profile.Interfaces.IRepositories.IUserRepository _profileUserRepository;

        public RegisterUseCase(
            IUserRepository userRepository,
            Contexts.Profile.Interfaces.IRepositories.IUserRepository profileUserRepository)
        {
            _userRepository = userRepository;
            _profileUserRepository = profileUserRepository;
        }

        public User? Run(RegisterRequest request)
        {
            var users = _userRepository.GetAll();
            if (users.FirstOrDefault(u => u.Email.Value == request.Email.Value) != null)
                return null;

            var newUser = new User();
            var hashedPassword = new PasswordHasher<User>().HashPassword(newUser, request.Password.Value);

            newUser.Id = Guid.NewGuid();
            newUser.Name = request.Name;
            newUser.Email = request.Email;
            newUser.PasswordHash = hashedPassword;
            newUser.ProfilePictureUrl = "";
            newUser.Sales = new List<Sale>();
            newUser.createdAt = DateOnly.FromDateTime(DateTime.Now);

            _userRepository.Create(newUser);

            // Cria o usuário espelho no contexto de Profile
            var profileUser = new Contexts.Profile.Entities.User
            {
                Name = new Contexts.Profile.ValueObjects.Name(request.Name.Value),
                Email = new Contexts.Profile.ValueObjects.Email(request.Email.Value),
                ProfilePictureUrl = ""
            };

            profileUser.SetId(newUser.Id); // mesmo ID para conseguir buscar esse usuário no contexto de profile

            _profileUserRepository.Create(profileUser);

            return newUser;
        }
    }
}