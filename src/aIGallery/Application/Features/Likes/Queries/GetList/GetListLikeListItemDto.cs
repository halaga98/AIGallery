using Core.Application.Dtos;

namespace Application.Features.Likes.Queries.GetList;

public class GetListLikeListItemDto : IDto
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public int ImageId { get; set; }
}