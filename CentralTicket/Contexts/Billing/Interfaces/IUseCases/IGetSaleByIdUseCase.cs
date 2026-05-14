using CentralTicket.Contexts.Billing.Entities;

namespace CentralTicket.Contexts.Billing.Interfaces.IUseCases
{
    public interface IGetSaleByIdUseCase
    {
        public Sale Run(Guid id);
    }
}
