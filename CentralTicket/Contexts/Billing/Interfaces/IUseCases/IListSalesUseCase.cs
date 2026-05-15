using CentralTicket.Contexts.Billing.DTOs.Sale;

namespace CentralTicket.Contexts.Billing.Interfaces.IUseCases
{
    public interface IListSalesUseCase
    {
        public List<ReadSaleDTO> Run();
    }
}
