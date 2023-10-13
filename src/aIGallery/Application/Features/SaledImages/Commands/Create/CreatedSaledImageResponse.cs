using Core.Application.Responses;

namespace Application.Features.SaledImages.Commands.Create;

public class CreatedSaledImageResponse : IResponse
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public int ImageId { get; set; }
}