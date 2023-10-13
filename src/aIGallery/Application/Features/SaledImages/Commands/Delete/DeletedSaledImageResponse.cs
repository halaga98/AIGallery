using Core.Application.Responses;

namespace Application.Features.SaledImages.Commands.Delete;

public class DeletedSaledImageResponse : IResponse
{
    public Guid Id { get; set; }
}