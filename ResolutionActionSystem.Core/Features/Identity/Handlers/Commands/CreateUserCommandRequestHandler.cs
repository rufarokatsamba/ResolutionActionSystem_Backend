using Axis.IntranetSystem.Application.Contracts.Identity;
using MediatR;
using ResolutionActionSystem.Application.Features.Identity.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolutionActionSystem.Application.Features.Identity.Handlers.Commands
{
    public class CreateUserCommandRequestHandler : IRequestHandler<CreateUserCommandRequest, int>
    {
        private readonly IUserService _identityService;
        public CreateUserCommandRequestHandler(IUserService identityService)
        {
            _identityService = identityService;
        }
        public async Task<int> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _identityService.CreateUserAsync(request.UserName, request.Password, request.Email, request.FirstName, request.LastName, request.PhoneNumber);
            return result.isSucceed ? 1 : 0;
        }
    }
}
