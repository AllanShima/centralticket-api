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
        //private readonly IUserRepository _userRepository;
        private readonly Contexts.Events.Interfaces.IRepositories.IEventRepository _eventRepository;
        private readonly Contexts.Auth.Interfaces.IRepositories.IUserRepository _authUserRepository;
        // private readonly Contexts.Profile.Interfaces.IRepositories.ISaleRepository _profileSaleRepository;
        // private readonly Contexts.Profile.Interfaces.IRepositories.IUserRepository _profileUserRepository;

        public CreateSaleUseCase(
            ISaleRepository saleRepository,
            //IUserRepository userRepository,
            Contexts.Auth.Interfaces.IRepositories.IUserRepository authUserRepository,
            Contexts.Events.Interfaces.IRepositories.IEventRepository eventRepository
            // Contexts.Profile.Interfaces.IRepositories.ISaleRepository profileSaleRepository,
            // Contexts.Profile.Interfaces.IRepositories.IUserRepository profileUserRepository
            )
        {
            _saleRepository = saleRepository;
            _authUserRepository = authUserRepository;
            //_userRepository = userRepository;
            _eventRepository = eventRepository;
            // _profileSaleRepository = profileSaleRepository;
            // _profileUserRepository = profileUserRepository;
        }

        public async Task Run(CreateSaleDTO sale)
        {
            // Busca o evento pra validar o estoque
            var ev = await _eventRepository.GetByIdAsync(sale.EventId);

            if (ev == null)
            {
                throw new ArgumentException($"Evento com id '{sale.EventId}' não encontrado.");
            }
            if (ev.Status == Contexts.Events.Enums.EventStatus.Shortly)       
            {
                throw new ArgumentException($"Ingressos ainda não disponíveis para o evento: '{ev.Title}'.");
            }
            if (ev.Status == Contexts.Events.Enums.EventStatus.SoldOut)
            {
                throw new ArgumentException($"Não há ingressos disponíveis para o evento: '{ev.Title}'.");
            }

            // Decrementa a quantidade de ingressos disponíveis no evento

            int ticketsQuantity = sale.Tickets.Count;
            bool success = ev.DecrementTickets(ticketsQuantity);

            if (!success)
            {
                ev.UpdateStatus(Contexts.Events.Enums.EventStatus.SoldOut);
                throw new InvalidOperationException($"Não há ingressos suficientes disponíveis para o evento '{ev.Title}'.");
            }

            await _eventRepository.UpdateAsync(ev);

            // --------

            //var customer = _userRepository.GetById(sale.UserId);
            var customer = _authUserRepository.GetById(sale.UserId);
            if (customer == null)
            {
                throw new ArgumentException($"Usuário com id '{sale.UserId}' não encontrado.", nameof(sale.UserId));
            }
                

            var newSale = new Sale
            {
                PaymentMethod = sale.PaymentMethod,
                CustomerId = sale.UserId,
                PurchasedTickets = new List<Ticket>()
            };

            newSale.UpdateTotalValue(sale.TotalValue);
            newSale.Status = SaleStatus.AwaitingApproval;

            var tickets = sale.Tickets.Select(t => new Ticket
            {
                Category = t.Category,
                Kind = t.Kind,
                Status = TicketStatus.Reserved,
                EventId = sale.EventId,         
                SaleId = newSale.Id
            }).ToList();

            newSale.PurchasedTickets = tickets;

            _saleRepository.Create(newSale);

            // O relacionamento já faz isso

            //foreach (var ticket in tickets)
            //{
            //    _ticketRepository.Create(ticket);
            //}

            // Espelha no Profile
            //var profileCustomer = _profileUserRepository.GetById(sale.UserId);

            //var profileTickets = tickets.Select(t => new Contexts.Profile.Entities.Ticket
            //{
            //    Category = t.Category.ToString(),
            //    Kind = t.Kind.ToString(),
            //}).ToList();

            //foreach (var pt in profileTickets)
            //    pt.SetId(tickets[profileTickets.IndexOf(pt)].Id);

            //var profileSale = new Contexts.Profile.Entities.Sale
            //{
            //    PaymentMethod = sale.PaymentMethod.ToString(),
            //    OrderCode = newSale.OrderCode.Value,
            //    Customer = profileCustomer,
            //    PurchasedTickets = profileTickets,
            //};

            //profileSale.SetId(newSale.Id);
            //profileSale.UpdateTotalValue(sale.TotalValue.Value);

            //_profileSaleRepository.Create(profileSale);
        }
    }
}
