using CentralTicket.Contexts.Billing.DTOs.Sale;

namespace CentralTicket.Contexts.Billing.Interfaces.IUseCases
{
    public interface IGetSaleByIdUseCase
    {
        public ReadSaleDTO Run(Guid id);
    }
}
