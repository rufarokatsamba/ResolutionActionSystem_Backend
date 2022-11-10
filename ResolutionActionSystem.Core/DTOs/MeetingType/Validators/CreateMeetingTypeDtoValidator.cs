using FluentValidation;

namespace ResolutionActionSystem.Application.DTOs.MeetingType.Validators
{
    public class CreateMeetingTypeDtoValidator : AbstractValidator<CreateMeetingTypeDto>
    {
        public CreateMeetingTypeDtoValidator()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Meeting type name is required.")
                .NotNull();
        }         
    }
}
