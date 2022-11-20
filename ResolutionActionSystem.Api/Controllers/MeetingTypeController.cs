using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResolutionActionSystem.Application.DTOs.MeetingType;
using ResolutionActionSystem.Application.Features.MeetingTypes.Requests.Commands;
using ResolutionActionSystem.Application.Features.MeetingTypes.Requests.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResolutionActionSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<MeetingTypeController> _logger;

        public MeetingTypeController(IMediator mediator, ILogger<MeetingTypeController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        // GET: api/<MeetingTypeController>
        [HttpGet]
        public async Task<ActionResult<List<MeetingTypeDto>>> GetAsync()
        {
            var meetingTypes = await _mediator.Send(new GetMeetingTypeListRequest());
            return Ok(meetingTypes);
        }

        // GET api/<MeetingTypeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MeetingTypeDto>> Get(int id)
        {
            _logger.LogInformation($"getting meeting type with id: {id}");
            var meetingType = await _mediator.Send(new GetMeetingTypeDetailRequest { Id = id });
            if (meetingType == null)
            {
                _logger.LogWarning($"meeting type with id: {id} not found");
            }
            return Ok(meetingType);
        }

        // POST api/<MeetingTypeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateMeetingTypeDto MeetingType)
        {
            var command = new CreateMeetingTypeCommand { CreateMeetingTypeDto = MeetingType };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
