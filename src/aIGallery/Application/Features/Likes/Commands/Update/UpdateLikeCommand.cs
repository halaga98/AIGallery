using Application.Features.Likes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Likes.Commands.Update;

public class UpdateLikeCommand : IRequest<UpdatedLikeResponse>, ICacheRemoverRequest
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public int ImageId { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetLikes";

    public class UpdateLikeCommandHandler : IRequestHandler<UpdateLikeCommand, UpdatedLikeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILikeRepository _likeRepository;
        private readonly LikeBusinessRules _likeBusinessRules;

        public UpdateLikeCommandHandler(IMapper mapper, ILikeRepository likeRepository,
                                         LikeBusinessRules likeBusinessRules)
        {
            _mapper = mapper;
            _likeRepository = likeRepository;
            _likeBusinessRules = likeBusinessRules;
        }

        public async Task<UpdatedLikeResponse> Handle(UpdateLikeCommand request, CancellationToken cancellationToken)
        {
            Like? like = await _likeRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);
            await _likeBusinessRules.LikeShouldExistWhenSelected(like);
            like = _mapper.Map(request, like);

            await _likeRepository.UpdateAsync(like!);

            UpdatedLikeResponse response = _mapper.Map<UpdatedLikeResponse>(like);
            return response;
        }
    }
}