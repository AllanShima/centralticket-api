using CentralTicket.Contexts.Auth.ValueObjects;

namespace CentralTicket.Contexts.Auth.Entities
{
    public class User
    {
        public int Id { get; set; }
        public Name Name { get; set; }
        public Password Password { get; set; }
        public Email Email { get; set; }
        public DateOnly createdAt { get; set; }
    }
}
