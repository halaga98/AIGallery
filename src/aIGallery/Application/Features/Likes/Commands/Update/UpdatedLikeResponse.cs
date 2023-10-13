using Core.Application.Responses;

namespace Application.Features.Likes.Commands.Update;

public class UpdatedLikeResponse : IResponse
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public int ImageId { get; set; }
}