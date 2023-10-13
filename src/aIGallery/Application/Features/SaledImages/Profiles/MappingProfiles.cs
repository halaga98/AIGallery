using Application.Features.SaledImages.Commands.Create;
using Application.Features.SaledImages.Commands.Delete;
using Application.Features.SaledImages.Commands.Update;
using Application.Features.SaledImages.Queries.GetById;
using Application.Features.SaledImages.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.SaledImages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<SaledImage, CreateSaledImageCommand>().ReverseMap();
        CreateMap<SaledImage, CreatedSaledImageResponse>().ReverseMap();
        CreateMap<SaledImage, UpdateSaledImageCommand>().ReverseMap();
        CreateMap<SaledImage, UpdatedSaledImageResponse>().ReverseMap();
        CreateMap<SaledImage, DeleteSaledImageCommand>().ReverseMap();
        CreateMap<SaledImage, DeletedSaledImageResponse>().ReverseMap();
        CreateMap<SaledImage, GetByIdSaledImageResponse>().ReverseMap();
        CreateMap<SaledImage, GetListSaledImageListItemDto>().ReverseMap();
        CreateMap<IPaginate<SaledImage>, GetListResponse<GetListSaledImageListItemDto>>().ReverseMap();
    }
}