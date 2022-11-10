
using FluentValidation;

namespace ResolutionActionSystem.Application.DTOs.Meeting.Validators
{
    public class CreateMeetingDtoValidator: AbstractValidator<CreateMeetingDto>
    {
        public CreateMeetingDtoValidator()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Meeting type is required.")
                .NotNull();
            RuleFor(c => c.MeetingDateAndTime)
                .NotEmpty().WithMessage("Meeting date is required.")
                .NotNull();
        }
    }
}
