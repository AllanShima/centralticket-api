using CentralTicket.Contexts.Billing.DTOs.Sale;
using CentralTicket.Contexts.Billing.Interfaces.IUseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CentralTicket.Contexts.Billing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly IListSalesUseCase _listSalesUseCase;
        private readonly IGetSaleByIdUseCase _getSaleByIdUseCase;
        private readonly ICreateSaleUseCase _createSaleUseCase;
        private readonly ICancelSaleUseCase _cancelSaleUseCase;
        private readonly IConfirmSaleUseCase _confirmSaleUseCase;

        public SalesController(
            IListSalesUseCase listSalesUseCase,
            IGetSaleByIdUseCase getSaleByIdUseCase,
            ICreateSaleUseCase createSaleUseCase,
            ICancelSaleUseCase cancelSaleUseCase,
            IConfirmSaleUseCase confirmSaleUseCase)
        {
            this._listSalesUseCase = listSalesUseCase;
            this._getSaleByIdUseCase = getSaleByIdUseCase;
            this._createSaleUseCase = createSaleUseCase;
            this._cancelSaleUseCase = cancelSaleUseCase;
            this._confirmSaleUseCase = confirmSaleUseCase;
        }

        [HttpGet("GetAll")]
        public IActionResult Index()
        {
            try
            {
                List<ReadSaleDTO> list = this._listSalesUseCase.Run();

                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("GetById")]
        public IActionResult GetById([FromQuery] Guid id)
        {
            try
            {
                ReadSaleDTO sale = this._getSaleByIdUseCase.Run(id);

                if (sale == null)
                {
                    return NotFound();
                }

                return Ok(sale);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateSaleDTO sale)
        {
            try
            {
                var result = await this._createSaleUseCase.Run(sale);

                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("Cancel")]
        public IActionResult Cancel([FromQuery] Guid id)
        {
            try
            {
                this._cancelSaleUseCase.Run(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("Confirm")]
        public IActionResult Confirm([FromQuery] Guid id)
        {
            try
            {
                this._confirmSaleUseCase.Run(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
