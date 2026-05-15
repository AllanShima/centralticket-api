using CentralTicket.Contexts.Billing.Entities;

namespace CentralTicket.Contexts.Billing.Interfaces.IRepositories
{
    public interface ITicketRepository
    {
        public List<Ticket> GetByIds(List<Guid> ids);
        public void Update(Ticket ticket);
    }
}
