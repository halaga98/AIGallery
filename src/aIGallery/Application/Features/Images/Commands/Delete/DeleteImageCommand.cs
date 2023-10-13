using Application.Features.Images.Constants;
using Application.Features.Images.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Images.Commands.Delete;

public class DeleteImageCommand : IRequest<DeletedImageResponse>, ICacheRemoverRequest
{
    public Guid Id { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetImages";

    public class DeleteImageCommandHandler : IRequestHandler<DeleteImageCommand, DeletedImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IImageRepository _imageRepository;
        private readonly ImageBusinessRules _imageBusinessRules;

        public DeleteImageCommandHandler(IMapper mapper, IImageRepository imageRepository,
                                         ImageBusinessRules imageBusinessRules)
        {
            _mapper = mapper;
            _imageRepository = imageRepository;
            _imageBusinessRules = imageBusinessRules;
        }

        public async Task<DeletedImageResponse> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
        {
            Image? image = await _imageRepository.GetAsync(predicate: i => i.Id == request.Id, cancellationToken: cancellationToken);
            await _imageBusinessRules.ImageShouldExistWhenSelected(image);

            await _imageRepository.DeleteAsync(image!);

            DeletedImageResponse response = _mapper.Map<DeletedImageResponse>(image);
            return response;
        }
    }
}