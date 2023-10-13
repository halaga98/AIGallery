using FluentValidation;

namespace Application.Features.SaledImages.Commands.Update;

public class UpdateSaledImageCommandValidator : AbstractValidator<UpdateSaledImageCommand>
{
    public UpdateSaledImageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.ImageId).NotEmpty();
    }
}