using Application.Features.Likes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Likes.Commands.Create;

public class CreateLikeCommand : IRequest<CreatedLikeResponse>, ICacheRemoverRequest
{
    public int UserId { get; set; }
    public int ImageId { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetLikes";

    public class CreateLikeCommandHandler : IRequestHandler<CreateLikeCommand, CreatedLikeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILikeRepository _likeRepository;
        private readonly LikeBusinessRules _likeBusinessRules;

        public CreateLikeCommandHandler(IMapper mapper, ILikeRepository likeRepository,
                                         LikeBusinessRules likeBusinessRules)
        {
            _mapper = mapper;
            _likeRepository = likeRepository;
            _likeBusinessRules = likeBusinessRules;
        }

        public async Task<CreatedLikeResponse> Handle(CreateLikeCommand request, CancellationToken cancellationToken)
        {
            Like like = _mapper.Map<Like>(request);

            await _likeRepository.AddAsync(like);

            CreatedLikeResponse response = _mapper.Map<CreatedLikeResponse>(like);
            return response;
        }
    }
}