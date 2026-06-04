using CentralTicket.Contexts.Billing.Entities;

namespace CentralTicket.Contexts.Billing.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        public User GetById(Guid id);
    }
}
