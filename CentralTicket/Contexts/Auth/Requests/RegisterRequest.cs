using CentralTicket.Contexts.Auth.ValueObjects;

namespace CentralTicket.Contexts.Auth.Requests
{
    public class RegisterRequest
    {
        public Name Name { get; set; }
        public Email Email { get; set; }
        public Password Password { get; set; } 

    }
}
