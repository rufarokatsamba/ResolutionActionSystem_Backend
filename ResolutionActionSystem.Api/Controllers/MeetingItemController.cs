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
        private readonly ILogger<MeetingItemController> _logger;

        public MeetingItemController(IMediator mediator, ILogger<MeetingItemController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        // GET: api/<MeetingItemController>
        [HttpGet]
        public async Task<ActionResult<List<MeetingItemDto>>> GetAsync()
        {
            var meetingItems = await _mediator.Send(new GetMeetingItemListRequest());
            return Ok(meetingItems);
        }

        // GET api/<MeetingItemController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MeetingItemDto>> Get(int id)
        {
            _logger.LogInformation($"getting meeting item with id: {id}");
            var meetingItem = await _mediator.Send(new GetMeetingItemDetailRequest { Id = id });
            if (meetingItem == null)
            {
                _logger.LogDebug($"meetingItem with id {id} not found");
            }
            return Ok(meetingItem);
        }

        // POST api/<MeetingItemController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateMeetingItemDto[] MeetingItem)
        {
            foreach (var item in MeetingItem)
            {
                var command = new CreateMeetingItemCommand { CreateMeetingItemDto = item };
                var response = await _mediator.Send(command);
               
                if (item.Equals(MeetingItem.Last()))
                {
                    return Ok(response);
                };
            }
            return Ok();

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
