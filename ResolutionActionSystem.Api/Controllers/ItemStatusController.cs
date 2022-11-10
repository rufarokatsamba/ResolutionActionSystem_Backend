using Microsoft.AspNetCore.Mvc;
using MediatR;
using ResolutionActionSystem.Application.DTOs.ItemStatus;
using ResolutionActionSystem.Application.Features.ItemStatuses.Requests.Queries;
using ResolutionActionSystem.Application.Features.ItemStatuses.Requests.Commands;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResolutionActionSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemStatusController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemStatusController(IMediator mediator)
        {
            _mediator = mediator;
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
            var status = await _mediator.Send(new GetItemStatusesDetailRequest { Id = id });
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
