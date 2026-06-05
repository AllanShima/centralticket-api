using CentralTicket.Contexts.Billing.DTOs.Sale;
using CentralTicket.Contexts.Billing.Entities;
using CentralTicket.Contexts.Billing.Enums;
using CentralTicket.Contexts.Billing.Interfaces.IRepositories;
using CentralTicket.Contexts.Billing.Interfaces.IUseCases;

namespace CentralTicket.Contexts.Billing.UseCases
{
    public class CreateSaleUseCase : ICreateSaleUseCase
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly Contexts.Profile.Interfaces.IRepositories.ISaleRepository _profileSaleRepository;
        private readonly Contexts.Profile.Interfaces.IRepositories.IUserRepository _profileUserRepository;

        public CreateSaleUseCase(
            ISaleRepository saleRepository,
            IUserRepository userRepository,
            ITicketRepository ticketRepository,
            Contexts.Profile.Interfaces.IRepositories.ISaleRepository profileSaleRepository,
            Contexts.Profile.Interfaces.IRepositories.IUserRepository profileUserRepository)
        {
            _saleRepository = saleRepository;
            _userRepository = userRepository;
            _ticketRepository = ticketRepository;
            _profileSaleRepository = profileSaleRepository;
            _profileUserRepository = profileUserRepository;
        }

        public void Run(CreateSaleDTO sale)
        {
            var customer = _userRepository.GetById(sale.UserId);
            var tickets = _ticketRepository.GetByIds(sale.TicketIds);

            var newSale = new Sale
            {
                PaymentMethod = sale.PaymentMethod,
                Customer = customer,
                PurchasedTickets = tickets,
            };

            newSale.UpdateTotalValue(sale.TotalValue);
            newSale.Status = SaleStatus.AwaitingApproval;

            _saleRepository.Create(newSale);

            foreach (var ticket in tickets)
            {
                ticket.Status = TicketStatus.Reserved;
                _ticketRepository.Update(ticket);
            }

            // Espelha no Profile
            var profileCustomer = _profileUserRepository.GetById(sale.UserId);

            var profileTickets = tickets.Select(t => new Contexts.Profile.Entities.Ticket
            {
                Category = t.Category.ToString(),
                Kind = t.Kind.ToString(),
            }).ToList();

            foreach (var pt in profileTickets)
                pt.SetId(tickets[profileTickets.IndexOf(pt)].Id);

            var profileSale = new Contexts.Profile.Entities.Sale
            {
                PaymentMethod = sale.PaymentMethod.ToString(),
                OrderCode = newSale.OrderCode.Value,
                Customer = profileCustomer,
                PurchasedTickets = profileTickets,
            };

            profileSale.SetId(newSale.Id);
            profileSale.UpdateTotalValue(sale.TotalValue.Value);

            _profileSaleRepository.Create(profileSale);
        }
    }
}
