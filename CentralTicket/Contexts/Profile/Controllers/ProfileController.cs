using CentralTicket.Contexts.Profile.DTOs.User;
using CentralTicket.Contexts.Profile.Interfaces.IUseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CentralTicket.Contexts.Profile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IGetUserByIdUseCase _getUser;
        private readonly IGetSalesByIdUseCase _getSales;
        private readonly IGetTicketsBySaleIdUseCase _getTickets;

        public ProfileController(
            IGetUserByIdUseCase getUser,
            IGetSalesByIdUseCase getSales,
            IGetTicketsBySaleIdUseCase getTickets)
        {
            _getUser = getUser;
            _getSales = getSales;
            _getTickets = getTickets;
        }

        [Authorize]
        [HttpGet("GetUserById")]
        public IActionResult GetById([FromQuery] Guid id)
        {
            try
            {
                ReadUserDTO user = this._getUser.Run(id);

                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("{id}/GetSaleByUserId")]
        public async Task<IActionResult> GetSales(Guid id)
        {
            var sales = await _getSales.Run(id);
            return Ok(sales);
        }

        [Authorize]
        [HttpGet("{id}/GetTicketsBySaleId")]
        public async Task<IActionResult> GetTickets(Guid id)
        {
            var tickets = _getTickets.Run(id);
            return Ok(tickets);
        }

       
    }
}
