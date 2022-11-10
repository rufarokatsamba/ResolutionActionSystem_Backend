using AutoMapper;
using MediatR;
using ResolutionActionSystem.Application.Contracts.Persistence;
using ResolutionActionSystem.Application.DTOs.ItemStatus;
using ResolutionActionSystem.Application.Features.ItemStatuses.Requests.Queries;

namespace ResolutionActionSystem.Application.Features.ItemStatuses.Handlers.Queries
{
    public class GetItemStatusesListRequestHandler : IRequestHandler<GetItemStatusesListRequest, List<ItemStatusListDto>>
    {
        private readonly IItemStatusRepository _itemStatusRepository;
        private readonly IMapper _mapper;
        public GetItemStatusesListRequestHandler(IItemStatusRepository itemStatusRepository, IMapper mapper)
        {
            _mapper = mapper;
            _itemStatusRepository = itemStatusRepository;
        }
        public async Task<List<ItemStatusListDto>> Handle(GetItemStatusesListRequest request, CancellationToken cancellationToken)
        {
            var statuses = await _itemStatusRepository.GetItemStatusesWithDetail();
            return _mapper.Map<List<ItemStatusListDto>>(statuses);
        }
    }
}
