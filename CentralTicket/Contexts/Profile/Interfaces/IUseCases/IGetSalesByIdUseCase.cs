using CentralTicket.Contexts.Profile.DTOs.Sale;

namespace CentralTicket.Contexts.Profile.Interfaces.IUseCases
{
    public interface IGetSalesByIdUseCase
    {
        public Task<List<ReadSaleDTO>> Run(Guid userId);
    }
}
