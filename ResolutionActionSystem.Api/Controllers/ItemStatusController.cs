using Microsoft.AspNetCore.Mvc;
using MediatR;
using ResolutionActionSystem.Application.DTOs.ItemStatus;
using ResolutionActionSystem.Application.Features.ItemStatuses.Requests.Queries;
using ResolutionActionSystem.Application.Features.ItemStatuses.Requests.Commands;

namespace ResolutionActionSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemStatusController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ItemStatusController> _logger;

        public ItemStatusController(IMediator mediator, ILogger<ItemStatusController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        // GET: api/<ItemStatusController>
        [HttpGet]
        public async Task<ActionResult<List<ItemStatusListDto>>> GetAsync()
        {
            var status = await _mediator.Send(new GetItemStatusesListRequest());
            return Ok(status);
        }

        // GET api/<ItemStatusController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemStatusListDto>> Get(int id)
        {
            _logger.LogInformation($"getting status with id {id} not found");
            var status = await _mediator.Send(new GetItemStatusesDetailRequest { Id = id });
            if (status == null)
            {
                _logger.LogWarning($"status with id {id} not found");
            }
            return Ok(status);
        }

        // POST api/<ItemStatusController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateItemStatusDto ItemStatus)
        {
            var command = new CreateItemStatusCommand { CreateItemStatusDto = ItemStatus };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
