using FluentValidation;

namespace Application.Features.Images.Commands.Create;

public class CreateImageCommandValidator : AbstractValidator<CreateImageCommand>
{
    public CreateImageCommandValidator()
    {
        RuleFor(c => c.ImageUrl).NotEmpty();
        RuleFor(c => c.Promt).NotEmpty();
        RuleFor(c => c.ArtStyleId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.CategoryId).NotEmpty();
        RuleFor(c => c.ImgToImg).NotEmpty();
        RuleFor(c => c.Discover).NotEmpty();
        RuleFor(c => c.SaleStatus).NotEmpty();
        RuleFor(c => c.SalePrice).NotEmpty();
        RuleFor(c => c.Blocked).NotEmpty();
    }
}