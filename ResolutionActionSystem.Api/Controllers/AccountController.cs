using Axis.IntranetSystem.Application.Contracts.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ResolutionActionSystem.Application.Contracts.Identity;
using ResolutionActionSystem.Application.DTOs.Identity;
using ResolutionActionSystem.Application.Features.Identity.Requests.Commands;
using ResolutionActionSystem.Application.Features.Identity.Requests.Queries;
using ResolutionActionSystem.Application.Models.Identity;

namespace ResolutionActionSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAuthService _authenticationService;
        public AccountController(IAuthService authenticationService, IMediator mediator)
        {
            _authenticationService = authenticationService;
            _mediator = mediator;
        }

        [HttpPost("Create")]
        [ProducesDefaultResponseType(typeof(int))]
        public async Task<ActionResult> CreateUser(CreateUserCommandRequest command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            return Ok(await _authenticationService.Login(request));
        }

        

        [HttpGet("GetAll")]
        [ProducesDefaultResponseType(typeof(List<UserResponseDto>))]
        public async Task<IActionResult> GetAllUserAsync()
        {
            return Ok(await _mediator.Send(new GetAllUsersDetailsQueryRequest()));
        }

        [HttpGet("GetUserDetails/{userId}")]
        [ProducesDefaultResponseType(typeof(Staff))]
        public async Task<IActionResult> GetUserDetails(string userId)
        {
            var result = await _mediator.Send(new GetUserDetailsQueryRequest() { UserId = userId });
            return Ok(result);
        }
    }
}
