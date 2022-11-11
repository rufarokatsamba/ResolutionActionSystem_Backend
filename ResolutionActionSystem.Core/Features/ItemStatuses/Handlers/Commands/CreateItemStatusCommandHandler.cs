using AutoMapper;
using MediatR;
using ResolutionActionSystem.Application.Contracts.Persistence;
using ResolutionActionSystem.Application.DTOs.ItemStatus.Validators;
using ResolutionActionSystem.Application.Exceptions;
using ResolutionActionSystem.Application.Features.ItemStatuses.Requests.Commands;
using ResolutionActionSystem.Application.Responses;
using ResolutionActionSystem.Domain.Entities;

namespace ResolutionActionSystem.Application.Features.ItemStatuses.Handlers.Commands
{
    public class CreateItemStatusCommandHandler : IRequestHandler<CreateItemStatusCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IItemStatusRepository _itemStatusRepository;
        public CreateItemStatusCommandHandler(IItemStatusRepository itemStatusRepository, IMapper mapper)
        {
            _itemStatusRepository = itemStatusRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateItemStatusCommand request, CancellationToken cancellationToken)
        {
            var responses = new BaseCommandResponse();
            var validator = new CreateItemStatusDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateItemStatusDto);


            var status = _mapper.Map<ItemStatus>(request.CreateItemStatusDto);

            status = await _itemStatusRepository.Add(status);
            if (validationResult.IsValid == false)
            {
                responses.Success = false;
                responses.Message = "Creation failed";
                responses.Error = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                throw new ValidationException(validationResult);
            }
            else
            {
                responses.Success = true;
                responses.Message = "Creation successful";
                responses.Name = request.CreateItemStatusDto.Description;
            }
            return responses;
        }
    }
}
