using CentralTicket.Contexts.Billing.DTOs.Sale;

namespace CentralTicket.Contexts.Billing.Interfaces.IRepositories
{
    public interface ISaleRepository
    {
        public List<ReadSaleDTO> List();
    }
}
