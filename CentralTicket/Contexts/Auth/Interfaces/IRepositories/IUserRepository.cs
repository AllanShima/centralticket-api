using CentralTicket.Contexts.Auth.Entities;

namespace CentralTicket.Contexts.Auth.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        public User? GetById(Guid id);
        public List<User> GetAll();
        public void Create(User newUser);
        public void SaveChanges();
    }
}
