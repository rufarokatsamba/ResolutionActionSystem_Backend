using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResolutionActionSystem.Application.DTOs.Meeting;
using ResolutionActionSystem.Application.Features.Meetings.Requests.Commands;
using ResolutionActionSystem.Application.Features.Meetings.Requests.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResolutionActionSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<MeetingController> _logger;
        public MeetingController(IMediator mediator, ILogger<MeetingController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        // GET: api/<MeetingController>
        [HttpGet]
        public async Task<ActionResult<List<MeetingDto>>> GetAsync()
        {
            var meetings = await _mediator.Send(new GetMeetingListRequest());

            if (meetings == null)
            {
                _logger.LogWarning($"No meetings found");
            }
            return Ok(meetings);
        }

        // GET api/<MeetingController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MeetingDto>> Get(int id)
        {
            _logger.LogInformation($"getting meeting with id: {id}");
            var meeting = await _mediator.Send(new GetMeetingDetailRequest { Id = id });
            if (meeting == null)
            {
                _logger.LogWarning($"meeting with id {id} not found");
            }
            return Ok(meeting);
        }

        // POST api/<MeetingController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateMeetingDto Meeting)
        {
            var command = new CreateMeetingCommand { CreateMeetingDto = Meeting };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
