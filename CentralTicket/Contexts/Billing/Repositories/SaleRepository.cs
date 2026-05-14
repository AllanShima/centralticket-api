using CentralTicket.Contexts.Billing.DTOs.Sale;
using CentralTicket.Contexts.Billing.Entities;
using CentralTicket.Contexts.Billing.Interfaces.IRepositories;
using CentralTicket.Contexts.Billing.Data;

namespace CentralTicket.Contexts.Billing.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly Context _database;
        public SaleRepository(Context database)
        {
            _database = database;
        }
        public List<ReadSaleDTO> List()
        {
            List<Sale> sales = _database.Sales.Select(sales => sales).ToList();

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
