using CentralTicket.Contexts.Auth.Entities;
using CentralTicket.Contexts.Auth.Interfaces.IRepositories;
using CentralTicket.Contexts.Auth.Requests;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

namespace CentralTicket.Contexts.Auth.UseCases
{
    public class LoginUseCase
    {
        private readonly CreateTokenUseCase _createTokenUseCase;

        private readonly IUserRepository _userRepository;

        public LoginUseCase(CreateTokenUseCase createTokenUseCase, IUserRepository userRepository)
        {
            this._createTokenUseCase = createTokenUseCase;
            _userRepository = userRepository;
        }

        public string? Run(LoginRequest request)
        {
            var users = _userRepository.GetAll();
            var user = users.FirstOrDefault(u => u.Email.Value == request.Email.Value);
            
            if (user == null)
            {
                return null;
            }
            
            if (new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, request.Password.Value) == PasswordVerificationResult.Failed)
            {
                return null;
            }

            var token = _createTokenUseCase.Run(user);
            return token;
        }
    }
}
