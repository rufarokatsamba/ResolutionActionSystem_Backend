using FluentValidation;

namespace ResolutionActionSystem.Application.DTOs.MeetingItem.Validators

{
    public class CreateMeetingItemDtoValidator : AbstractValidator<CreateMeetingItemDto>
    {
        public CreateMeetingItemDtoValidator()
        {
            RuleFor(c => c.PersonResponsible)
                .NotEmpty().WithMessage("Person responsible is required.")
                .NotNull();
            RuleFor(c => c.Status)
                .NotEmpty().WithMessage("Status is required.")
                .NotNull();
            RuleFor(c => c.DueDate)
                .NotEmpty().WithMessage("Item Due Date is required.")
                .NotNull();
            RuleFor(c => c.ItemComment)
                .NotEmpty().WithMessage("Item description is required.")
                .NotNull();
        }
    }
}
