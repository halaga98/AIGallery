using FluentValidation;

namespace Application.Features.Likes.Commands.Update;

public class UpdateLikeCommandValidator : AbstractValidator<UpdateLikeCommand>
{
    public UpdateLikeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.ImageId).NotEmpty();
    }
}