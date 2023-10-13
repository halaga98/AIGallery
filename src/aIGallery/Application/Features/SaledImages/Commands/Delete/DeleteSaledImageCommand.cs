using Application.Features.SaledImages.Constants;
using Application.Features.SaledImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.SaledImages.Commands.Delete;

public class DeleteSaledImageCommand : IRequest<DeletedSaledImageResponse>, ICacheRemoverRequest
{
    public Guid Id { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSaledImages";

    public class DeleteSaledImageCommandHandler : IRequestHandler<DeleteSaledImageCommand, DeletedSaledImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISaledImageRepository _saledImageRepository;
        private readonly SaledImageBusinessRules _saledImageBusinessRules;

        public DeleteSaledImageCommandHandler(IMapper mapper, ISaledImageRepository saledImageRepository,
                                         SaledImageBusinessRules saledImageBusinessRules)
        {
            _mapper = mapper;
            _saledImageRepository = saledImageRepository;
            _saledImageBusinessRules = saledImageBusinessRules;
        }

        public async Task<DeletedSaledImageResponse> Handle(DeleteSaledImageCommand request, CancellationToken cancellationToken)
        {
            SaledImage? saledImage = await _saledImageRepository.GetAsync(predicate: si => si.Id == request.Id, cancellationToken: cancellationToken);
            await _saledImageBusinessRules.SaledImageShouldExistWhenSelected(saledImage);

            await _saledImageRepository.DeleteAsync(saledImage!);

            DeletedSaledImageResponse response = _mapper.Map<DeletedSaledImageResponse>(saledImage);
            return response;
        }
    }
}