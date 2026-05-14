using CentralTicket.Contexts.Billing.DTOs.Sale;
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
            List<ReadSaleDTO> sales = new List<ReadSaleDTO>();

            sales = this._saleRepository.List();

            return sales;
        }
    }
}
