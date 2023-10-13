using Core.Application.Dtos;

namespace Application.Features.Images.Queries.GetList;

public class GetListImageListItemDto : IDto
{
    public Guid Id { get; set; }
    public string ImageUrl { get; set; }
    public string Promt { get; set; }
    public int ArtStyleId { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public string ImgToImg { get; set; }
    public bool Discover { get; set; }
    public bool SaleStatus { get; set; }
    public int SalePrice { get; set; }
    public bool Blocked { get; set; }
}