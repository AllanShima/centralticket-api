using CentralTicket.Contexts.Auth.ValueObjects;

namespace CentralTicket.Contexts.Auth.Requests
{
    public class LoginRequest
    {
        public Email Email { get; set; }
        public Password Password { get; set; }
    }
}
