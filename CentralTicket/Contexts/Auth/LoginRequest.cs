using CentralTicket.Contexts.Auth.ValueObjects;

namespace CentralTicket.Contexts.Auth
{
    public interface LoginRequest
    {
        public Email Email { get; set; }
        public Password Password { get; set; }
    }
}
