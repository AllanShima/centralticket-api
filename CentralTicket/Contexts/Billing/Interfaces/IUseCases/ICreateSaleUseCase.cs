using CentralTicket.Contexts.Billing.DTOs.Sale;

namespace CentralTicket.Contexts.Billing.Interfaces.IUseCases
{
    public interface ICreateSaleUseCase
    {
        public Task Run(CreateSaleDTO sale);
    }
}
