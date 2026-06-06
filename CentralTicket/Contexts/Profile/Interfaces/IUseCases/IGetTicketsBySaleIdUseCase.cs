using CentralTicket.Contexts.Profile.DTOs.Ticket;

namespace CentralTicket.Contexts.Profile.Interfaces.IUseCases
{
    public interface IGetTicketsBySaleIdUseCase
    {
        public List<ReadTicketDTO> Run(Guid saleId);
    }
}
