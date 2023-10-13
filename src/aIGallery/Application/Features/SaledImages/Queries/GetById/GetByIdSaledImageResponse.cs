using Core.Application.Responses;

namespace Application.Features.SaledImages.Queries.GetById;

public class GetByIdSaledImageResponse : IResponse
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public int ImageId { get; set; }
}