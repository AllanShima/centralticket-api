namespace CentralTicket.Contexts.Billing.Interfaces.IUseCases
{
    public interface ICancelSaleUseCase
    {
        public void Run(Guid id);
    }
}
