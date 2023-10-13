using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SaledImages.Queries.GetList;

public class GetListSaledImageQuery : IRequest<GetListResponse<GetListSaledImageListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; }
    public string CacheKey => $"GetListSaledImages({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetSaledImages";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListSaledImageQueryHandler : IRequestHandler<GetListSaledImageQuery, GetListResponse<GetListSaledImageListItemDto>>
    {
        private readonly ISaledImageRepository _saledImageRepository;
        private readonly IMapper _mapper;

        public GetListSaledImageQueryHandler(ISaledImageRepository saledImageRepository, IMapper mapper)
        {
            _saledImageRepository = saledImageRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSaledImageListItemDto>> Handle(GetListSaledImageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<SaledImage> saledImages = await _saledImageRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSaledImageListItemDto> response = _mapper.Map<GetListResponse<GetListSaledImageListItemDto>>(saledImages);
            return response;
        }
    }
}