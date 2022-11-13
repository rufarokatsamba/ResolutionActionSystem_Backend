using MediatR;
using ResolutionActionSystem.Application.DTOs.Identity;
using ResolutionActionSystem.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolutionActionSystem.Application.Features.Identity.Requests.Queries
{
    public class GetUserDetailsQueryRequest : IRequest<Staff>
    {
        public string UserId { get; set; }
    }
}