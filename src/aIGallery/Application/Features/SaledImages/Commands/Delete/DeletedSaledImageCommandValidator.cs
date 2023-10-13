using FluentValidation;

namespace Application.Features.SaledImages.Commands.Delete;

public class DeleteSaledImageCommandValidator : AbstractValidator<DeleteSaledImageCommand>
{
    public DeleteSaledImageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}