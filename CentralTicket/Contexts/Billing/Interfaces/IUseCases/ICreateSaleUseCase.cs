using CentralTicket.Contexts.Billing.DTOs.Sale;
using CentralTicket.Contexts.Billing.Entities;

namespace CentralTicket.Contexts.Billing.Interfaces.IUseCases
{
    public interface ICreateSaleUseCase
    {
        public Task<Sale> Run(CreateSaleDTO sale);
    }
}
