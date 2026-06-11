namespace CentralTicket.Contexts.Profile.UseCases
{
    using CentralTicket.Contexts.Profile.DTOs.Ticket;
    using CentralTicket.Contexts.Profile.Interfaces.IRepositories;
    using CentralTicket.Contexts.Profile.Interfaces.IUseCases;

    public class GetTicketsBySaleIdUseCase : IGetTicketsBySaleIdUseCase
    {
        private readonly Contexts.Billing.Interfaces.IRepositories.ISaleRepository _billingSaleRepository;
        private readonly Contexts.Events.Interfaces.IRepositories.IEventRepository _eventsRepository;

        public GetTicketsBySaleIdUseCase(
            Contexts.Billing.Interfaces.IRepositories.ISaleRepository billingSaleRepository,
            Contexts.Events.Interfaces.IRepositories.IEventRepository eventsRepository)
        {
            _billingSaleRepository = billingSaleRepository;
            _eventsRepository = eventsRepository;
        }

        public List<ReadTicketDTO> Run(Guid saleId)
        {
            var sale = _billingSaleRepository.GetById(saleId);

            if (sale == null || sale.PurchasedTickets == null)
            {
                throw new ArgumentException($"Venda com o id {saleId} não foi encontrada ou não possui tickets associados");
            }

            return sale.PurchasedTickets.Select(t => {
                var currentEvent = _eventsRepository.GetByIdAsync(t.EventId).Result;

                return new ReadTicketDTO
                {
                    Id = t.Id,
                    Status = t.Status.ToString(),
                    EventTitle = currentEvent != null ? currentEvent.Title : "Evento não encontrado",
                    EventLocation = currentEvent != null ? currentEvent.Location : "Localização não encontrada",
                    EventImageUrl = currentEvent != null ? currentEvent.ImageUrl : "Imagem não encontrada",
                    EventStartDate = currentEvent != null ? currentEvent.StartDate : default,
                    EventEndDate = currentEvent != null ? currentEvent.EndDate : default
                };
            }).ToList();
        }
    }
}