using CentralTicket.Contexts.Billing.DTOs.Sale;
using CentralTicket.Contexts.Billing.Entities;
using CentralTicket.Contexts.Billing.Interfaces.IRepositories;
using CentralTicket.Contexts.Billing.Interfaces.IUseCases;

namespace CentralTicket.Contexts.Billing.UseCases
{
    public class GetSaleByIdUseCase : IGetSaleByIdUseCase
    {
        private readonly ISaleRepository _saleRepository;
        public GetSaleByIdUseCase(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public ReadSaleDTO Run(Guid id)
        {
            Sale sale = this._saleRepository.GetById(id);

            if (sale == null) throw new Exception("Venda não encontrada");
            
            return new ReadSaleDTO
            {
                Id = sale.Id,
                TotalValue = sale.TotalValue,
                PaymentMethod = sale.PaymentMethod,
                Status = sale.Status,
                OrderCode = sale.OrderCode,
                Customer = sale.Customer,
                PurchasedTickets = sale.PurchasedTickets,
                CreatedAt = sale.CreatedAt,
            };
        }
    }
}
