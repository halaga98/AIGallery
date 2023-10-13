using Application.Features.SaledImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.SaledImages.Commands.Create;

public class CreateSaledImageCommand : IRequest<CreatedSaledImageResponse>, ICacheRemoverRequest
{
    public int UserId { get; set; }
    public int ImageId { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSaledImages";

    public class CreateSaledImageCommandHandler : IRequestHandler<CreateSaledImageCommand, CreatedSaledImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISaledImageRepository _saledImageRepository;
        private readonly SaledImageBusinessRules _saledImageBusinessRules;

        public CreateSaledImageCommandHandler(IMapper mapper, ISaledImageRepository saledImageRepository,
                                         SaledImageBusinessRules saledImageBusinessRules)
        {
            _mapper = mapper;
            _saledImageRepository = saledImageRepository;
            _saledImageBusinessRules = saledImageBusinessRules;
        }

        public async Task<CreatedSaledImageResponse> Handle(CreateSaledImageCommand request, CancellationToken cancellationToken)
        {
            SaledImage saledImage = _mapper.Map<SaledImage>(request);

            await _saledImageRepository.AddAsync(saledImage);

            CreatedSaledImageResponse response = _mapper.Map<CreatedSaledImageResponse>(saledImage);
            return response;
        }
    }
}