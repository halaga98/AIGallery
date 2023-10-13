using Core.Application.Responses;

namespace Application.Features.SaledImages.Commands.Update;

public class UpdatedSaledImageResponse : IResponse
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public int ImageId { get; set; }
}