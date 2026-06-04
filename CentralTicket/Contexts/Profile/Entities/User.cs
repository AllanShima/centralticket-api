using CentralTicket.Contexts.Profile.ValueObjects;
using CentralTicket.Entities;

namespace CentralTicket.Contexts.Profile.Entities
{
    public class User : Base
    {
        public Name Name { get; set; }
        public Password Password { get; set; }
        public Email Email { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
}
