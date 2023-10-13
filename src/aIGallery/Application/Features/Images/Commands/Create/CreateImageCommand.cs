using Application.Features.Images.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Images.Commands.Create;

public class CreateImageCommand : IRequest<CreatedImageResponse>, ICacheRemoverRequest
{
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

    public class CreateImageCommandHandler : IRequestHandler<CreateImageCommand, CreatedImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IImageRepository _imageRepository;
        private readonly ImageBusinessRules _imageBusinessRules;

        public CreateImageCommandHandler(IMapper mapper, IImageRepository imageRepository,
                                         ImageBusinessRules imageBusinessRules)
        {
            _mapper = mapper;
            _imageRepository = imageRepository;
            _imageBusinessRules = imageBusinessRules;
        }

        public async Task<CreatedImageResponse> Handle(CreateImageCommand request, CancellationToken cancellationToken)
        {
            Image image = _mapper.Map<Image>(request);

            await _imageRepository.AddAsync(image);

            CreatedImageResponse response = _mapper.Map<CreatedImageResponse>(image);
            return response;
        }
    }
}