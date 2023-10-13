using FluentValidation;

namespace Application.Features.Images.Commands.Update;

public class UpdateImageCommandValidator : AbstractValidator<UpdateImageCommand>
{
    public UpdateImageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
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