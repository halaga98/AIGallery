using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Likes.Queries.GetList;

public class GetListLikeQuery : IRequest<GetListResponse<GetListLikeListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; }
    public string CacheKey => $"GetListLikes({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetLikes";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListLikeQueryHandler : IRequestHandler<GetListLikeQuery, GetListResponse<GetListLikeListItemDto>>
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IMapper _mapper;

        public GetListLikeQueryHandler(ILikeRepository likeRepository, IMapper mapper)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListLikeListItemDto>> Handle(GetListLikeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Like> likes = await _likeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListLikeListItemDto> response = _mapper.Map<GetListResponse<GetListLikeListItemDto>>(likes);
            return response;
        }
    }
}