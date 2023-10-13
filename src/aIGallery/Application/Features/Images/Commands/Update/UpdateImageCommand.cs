using Application.Features.Images.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Images.Commands.Update;

public class UpdateImageCommand : IRequest<UpdatedImageResponse>, ICacheRemoverRequest
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

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetImages";

    public class UpdateImageCommandHandler : IRequestHandler<UpdateImageCommand, UpdatedImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IImageRepository _imageRepository;
        private readonly ImageBusinessRules _imageBusinessRules;

        public UpdateImageCommandHandler(IMapper mapper, IImageRepository imageRepository,
                                         ImageBusinessRules imageBusinessRules)
        {
            _mapper = mapper;
            _imageRepository = imageRepository;
            _imageBusinessRules = imageBusinessRules;
        }

        public async Task<UpdatedImageResponse> Handle(UpdateImageCommand request, CancellationToken cancellationToken)
        {
            Image? image = await _imageRepository.GetAsync(predicate: i => i.Id == request.Id, cancellationToken: cancellationToken);
            await _imageBusinessRules.ImageShouldExistWhenSelected(image);
            image = _mapper.Map(request, image);

            await _imageRepository.UpdateAsync(image!);

            UpdatedImageResponse response = _mapper.Map<UpdatedImageResponse>(image);
            return response;
        }
    }
}