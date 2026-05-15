using CentralTicket.Contexts.Billing.DTOs.Sale;
using CentralTicket.Contexts.Billing.Entities;
using CentralTicket.Contexts.Billing.Interfaces.IRepositories;
using CentralTicket.Contexts.Billing.Interfaces.IUseCases;

namespace CentralTicket.Contexts.Billing.UseCases
{
    public class ListSalesUseCase : IListSalesUseCase
    {
        private readonly ISaleRepository _saleRepository;
        public ListSalesUseCase(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public List<ReadSaleDTO> Run()
        {
            List<Sale> sales = new List<Sale>();

            sales = this._saleRepository.List();

            return sales.Select(sale => new ReadSaleDTO
            {
                Id = sale.Id,
                TotalValue = sale.TotalValue,
                PaymentMethod = sale.PaymentMethod,
                Status = sale.Status,
                OrderCode = sale.OrderCode,
                Customer = sale.Customer,
                PurchasedTickets = sale.PurchasedTickets,
                CreatedAt = sale.CreatedAt,
            }).ToList();
        }
    }
}
