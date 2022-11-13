using Axis.IntranetSystem.Application.Contracts.Identity;
using MediatR;
using ResolutionActionSystem.Application.DTOs.Identity;
using ResolutionActionSystem.Application.Features.Identity.Requests.Queries;
using ResolutionActionSystem.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolutionActionSystem.Application.Features.Identity.Handlers.Queries
{
    public class GetAllUsersDetailsRequestQueryHandler : IRequestHandler<GetAllUsersDetailsQueryRequest, List<Staff>>
    {
        private readonly IUserService _identityService;

        public GetAllUsersDetailsRequestQueryHandler(IUserService identityService)
        {
            _identityService = identityService;
        }
        public async Task<List<Staff>> Handle(GetAllUsersDetailsQueryRequest request, CancellationToken cancellationToken)
        {
            var users = await _identityService.GetAllUsersAsync();
            var userDetails = users.Select(x => new Staff()
            {
                Id = x.id,
                Email = x.email,
                UserName = x.userName,
                FirstName = x.firstName,
                LastName = x.lastName,
                PhoneNumber = x.phoneNumber

            }).ToList();
            return userDetails;
        }
    }
}