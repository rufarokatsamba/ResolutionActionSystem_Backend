using FluentValidation;

namespace ResolutionActionSystem.Application.DTOs.MeetingItem.Validators

{
    public class UpdateMeetingItemDtoValidator : AbstractValidator<UpdateMeetingItemDto>
    {
        public UpdateMeetingItemDtoValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Select meeting item to update.")
                .NotNull();
        }
    }
}
