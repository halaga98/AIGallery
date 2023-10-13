using FluentValidation;

namespace Application.Features.SaledImages.Commands.Create;

public class CreateSaledImageCommandValidator : AbstractValidator<CreateSaledImageCommand>
{
    public CreateSaledImageCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.ImageId).NotEmpty();
    }
}