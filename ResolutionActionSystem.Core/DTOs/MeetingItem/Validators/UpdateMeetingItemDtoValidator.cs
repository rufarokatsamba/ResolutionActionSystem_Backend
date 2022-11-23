using FluentValidation;
using ResolutionActionSystem.Application.Contracts.Persistence;

namespace ResolutionActionSystem.Application.DTOs.MeetingItem.Validators

{
    public class UpdateMeetingItemDtoValidator : AbstractValidator<UpdateMeetingItemDto>
    {
        private readonly IMeetingItemRepository _meetingItemRepository;
        public UpdateMeetingItemDtoValidator(IMeetingItemRepository meetingItemRepository)
        {
            _meetingItemRepository = meetingItemRepository;

            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Select meeting item to update.")
                .NotNull();
            RuleFor(c => c.Id)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var meetingTypeExists = await _meetingItemRepository.Exists(id);
                    return !meetingTypeExists;
                })
                .WithMessage("{PropertyName} does not exist.");
        }
    }
}
