
using MediatR;
using ResolutionActionSystem.Application.DTOs.ItemStatus;
using ResolutionActionSystem.Application.Responses;

namespace ResolutionActionSystem.Application.Features.ItemStatuses.Requests.Commands

{
    public class CreateItemStatusCommand : IRequest<BaseCommandResponse>
    {
        public CreateItemStatusDto CreateItemStatusDto { get; set; }
    }
}
