using CentralTicket.Contexts.Billing.DTOs.Sale;

namespace CentralTicket.Contexts.Billing.Interfaces.IUseCases
{
    public interface ICreateSaleUseCase
    {
        public void Run(CreateSaleDTO sale);
    }
}
