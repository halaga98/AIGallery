using Application.Features.SaledImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.SaledImages.Commands.Update;

public class UpdateSaledImageCommand : IRequest<UpdatedSaledImageResponse>, ICacheRemoverRequest
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public int ImageId { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSaledImages";

    public class UpdateSaledImageCommandHandler : IRequestHandler<UpdateSaledImageCommand, UpdatedSaledImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISaledImageRepository _saledImageRepository;
        private readonly SaledImageBusinessRules _saledImageBusinessRules;

        public UpdateSaledImageCommandHandler(IMapper mapper, ISaledImageRepository saledImageRepository,
                                         SaledImageBusinessRules saledImageBusinessRules)
        {
            _mapper = mapper;
            _saledImageRepository = saledImageRepository;
            _saledImageBusinessRules = saledImageBusinessRules;
        }

        public async Task<UpdatedSaledImageResponse> Handle(UpdateSaledImageCommand request, CancellationToken cancellationToken)
        {
            SaledImage? saledImage = await _saledImageRepository.GetAsync(predicate: si => si.Id == request.Id, cancellationToken: cancellationToken);
            await _saledImageBusinessRules.SaledImageShouldExistWhenSelected(saledImage);
            saledImage = _mapper.Map(request, saledImage);

            await _saledImageRepository.UpdateAsync(saledImage!);

            UpdatedSaledImageResponse response = _mapper.Map<UpdatedSaledImageResponse>(saledImage);
            return response;
        }
    }
}