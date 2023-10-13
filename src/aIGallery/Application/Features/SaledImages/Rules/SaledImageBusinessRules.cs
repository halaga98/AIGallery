using Application.Features.SaledImages.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.SaledImages.Rules;

public class SaledImageBusinessRules : BaseBusinessRules
{
    private readonly ISaledImageRepository _saledImageRepository;

    public SaledImageBusinessRules(ISaledImageRepository saledImageRepository)
    {
        _saledImageRepository = saledImageRepository;
    }

    public Task SaledImageShouldExistWhenSelected(SaledImage? saledImage)
    {
        if (saledImage == null)
            throw new BusinessException(SaledImagesBusinessMessages.SaledImageNotExists);
        return Task.CompletedTask;
    }

    public async Task SaledImageIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        SaledImage? saledImage = await _saledImageRepository.GetAsync(
            predicate: si => si.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SaledImageShouldExistWhenSelected(saledImage);
    }
}