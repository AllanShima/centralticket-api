namespace CentralTicket.Contexts.Profile.UseCases
{
    using CentralTicket.Contexts.Profile.DTOs.Sale;
    using CentralTicket.Contexts.Profile.DTOs.Ticket;
    using CentralTicket.Contexts.Profile.Interfaces.IRepositories;
    using CentralTicket.Contexts.Profile.Interfaces.IUseCases;

    public class GetSalesByUserIdUseCase : IGetSalesByIdUseCase
    {
        private readonly Contexts.Billing.Interfaces.IRepositories.ISaleRepository _billingSaleRepository;
        private readonly Contexts.Events.Interfaces.IRepositories.IEventRepository _eventsRepository;
        public GetSalesByUserIdUseCase(Contexts.Billing.Interfaces.IRepositories.ISaleRepository billingSaleRepository, Contexts.Events.Interfaces.IRepositories.IEventRepository eventsRepository)
        {
            _billingSaleRepository = billingSaleRepository;
            _eventsRepository = eventsRepository;
        }

        public async Task<List<ReadSaleDTO>> Run(Guid userId)
        {
            var userSales = _billingSaleRepository.List()
                    .Where(s => s.CustomerId == userId)
                    .ToList();

            if (userSales == null)
            {
                throw new ArgumentException("Nenhuma venda encontrada, ou id errado.");
            }

            var events = await _eventsRepository.GetAllAsync();

            return userSales.Select(s => new ReadSaleDTO
            {
                Id = s.Id,
                TotalValue = s.TotalValue.Value,
                PaymentMethod = s.PaymentMethod.ToString(),
                OrderCode = s.OrderCode.Value,
                PurchasedTickets = s.PurchasedTickets.Select(t =>
                {
                    var currentEvent = events.FirstOrDefault(e => e.Id == t.EventId);

                    return new ReadTicketDTO
                    {
                        Id = t.Id,
                        Status = t.Status.ToString(),
                        EventTitle = currentEvent?.Title ?? "Evento Não Encontrado",
                        EventStartDate = currentEvent?.StartDate ?? DateTime.MinValue,
                        EventEndDate = currentEvent?.EndDate ?? DateTime.MinValue
                    };
                }).ToList()
            }).ToList();
        }
    }
}