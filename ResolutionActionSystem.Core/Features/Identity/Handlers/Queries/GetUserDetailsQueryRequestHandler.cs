using Axis.IntranetSystem.Application.Contracts.Identity;
using MediatR;
using ResolutionActionSystem.Application.Features.Identity.Requests.Queries;
using ResolutionActionSystem.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolutionActionSystem.Application.Features.Identity.Handlers.Queries
{
    public class GetUserDetailsQueryRequestHandler : IRequestHandler<GetUserDetailsQueryRequest, Staff>
    {
        private readonly IUserService _identityService;

        public GetUserDetailsQueryRequestHandler(IUserService identityService)
        {
            _identityService = identityService;
        }
        public async Task<Staff> Handle(GetUserDetailsQueryRequest request, CancellationToken cancellationToken)
        {
            var (userId, firstName, lastName, userName, email, phoneNumber) = await _identityService.GetUserDetailsAsync(request.UserId);
            return new Staff { Id = userId, FirstName = firstName, LastName = lastName, UserName = userName, Email = email, PhoneNumber = phoneNumber };
        }
    }
}