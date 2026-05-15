using CentralTicket.Contexts.Billing.Entities;

namespace CentralTicket.Contexts.Billing.Interfaces.IRepositories
{
    public interface ISaleRepository
    {
        public List<Sale> List();
        public Sale GetById(Guid id);
        public void Create(Sale newSale);
        public void Update(Sale sale);
    }
}
