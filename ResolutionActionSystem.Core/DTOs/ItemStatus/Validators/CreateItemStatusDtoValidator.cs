using FluentValidation;

namespace ResolutionActionSystem.Application.DTOs.ItemStatus.Validators
{
    public class CreateItemStatusDtoValidator: AbstractValidator<CreateItemStatusDto>
    {
        public CreateItemStatusDtoValidator()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("status description is required.")
                .NotNull();
        }
    }
}
