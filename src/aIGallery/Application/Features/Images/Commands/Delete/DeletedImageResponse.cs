using Core.Application.Responses;

namespace Application.Features.Images.Commands.Delete;

public class DeletedImageResponse : IResponse
{
    public Guid Id { get; set; }
}