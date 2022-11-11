using FluentValidation;

namespace ResolutionActionSystem.Application.DTOs.MeetingType.Validators
{
    public class CreateMeetingTypeDtoValidator : AbstractValidator<CreateMeetingTypeDto>
    {
        public CreateMeetingTypeDtoValidator()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Meeting type name is required.")
                .NotNull().WithMessage("Meeting type name cannot be null.")
                .MinimumLength(1).WithMessage("Meeting type name should be more descriptive.");
        }         
    }
}
