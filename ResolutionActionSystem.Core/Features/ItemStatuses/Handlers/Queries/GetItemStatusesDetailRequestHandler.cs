using AutoMapper;
using MediatR;
using ResolutionActionSystem.Application.Contracts.Persistence;
using ResolutionActionSystem.Application.DTOs.ItemStatus;
using ResolutionActionSystem.Application.Features.ItemStatuses.Requests.Queries;

namespace ResolutionActionSystem.Application.Features.ItemStatuses.Handlers.Queries
{
    public class GetItemStatusesDetailRequestHandler : IRequestHandler<GetItemStatusesDetailRequest, ItemStatusDto>
    {
        private readonly IItemStatusRepository _itemStatusRepository;
        private readonly IMapper _mapper;
        public GetItemStatusesDetailRequestHandler(IItemStatusRepository itemStatusRepository, IMapper mapper)
        {
            _mapper = mapper;
            _itemStatusRepository = itemStatusRepository;
        }
        public async Task<ItemStatusDto> Handle(GetItemStatusesDetailRequest request, CancellationToken cancellationToken)
        {
            var itemStatus = await _itemStatusRepository.GetItemStatusWithDetail(request.Id);
            return _mapper.Map<ItemStatusDto>(itemStatus);
        }
    }
}
