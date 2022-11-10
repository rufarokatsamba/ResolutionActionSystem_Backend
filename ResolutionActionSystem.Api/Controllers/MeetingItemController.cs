using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResolutionActionSystem.Application.DTOs.MeetingItem;
using ResolutionActionSystem.Application.Features.MeetingItems.Requests.Commands;
using ResolutionActionSystem.Application.Features.MeetingItems.Requests.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResolutionActionSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MeetingItemController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<MeetingItemController>
        [HttpGet]
        public async Task<ActionResult<List<MeetingItemDto>>> GetAsync()
        {
            var meetings = await _mediator.Send(new GetMeetingItemListRequest());
            return Ok(meetings);
        }

        // GET api/<MeetingItemController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MeetingItemDto>> Get(int id)
        {
            var meeting = await _mediator.Send(new GetMeetingItemDetailRequest { Id = id });
            return Ok(meeting);
        }

        // POST api/<MeetingItemController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateMeetingItemDto MeetingItem)
        {
            var command = new CreateMeetingItemCommand { CreateMeetingItemDto = MeetingItem };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<MeetingItemController>/5
        [HttpPut]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put([FromBody] UpdateMeetingItemDto MeetingItem)
        {
            var command = new UpdateMeetingItemCommand { UpdateMeetingItemDto = MeetingItem };
            await _mediator.Send(command);
            return NoContent();
        }
        
    }
}
