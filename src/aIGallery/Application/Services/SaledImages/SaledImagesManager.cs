using Application.Features.SaledImages.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SaledImages;

public class SaledImagesManager : ISaledImagesService
{
    private readonly ISaledImageRepository _saledImageRepository;
    private readonly SaledImageBusinessRules _saledImageBusinessRules;

    public SaledImagesManager(ISaledImageRepository saledImageRepository, SaledImageBusinessRules saledImageBusinessRules)
    {
        _saledImageRepository = saledImageRepository;
        _saledImageBusinessRules = saledImageBusinessRules;
    }

    public async Task<SaledImage?> GetAsync(
        Expression<Func<SaledImage, bool>> predicate,
        Func<IQueryable<SaledImage>, IIncludableQueryable<SaledImage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        SaledImage? saledImage = await _saledImageRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return saledImage;
    }

    public async Task<IPaginate<SaledImage>?> GetListAsync(
        Expression<Func<SaledImage, bool>>? predicate = null,
        Func<IQueryable<SaledImage>, IOrderedQueryable<SaledImage>>? orderBy = null,
        Func<IQueryable<SaledImage>, IIncludableQueryable<SaledImage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<SaledImage> saledImageList = await _saledImageRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return saledImageList;
    }

    public async Task<SaledImage> AddAsync(SaledImage saledImage)
    {
        SaledImage addedSaledImage = await _saledImageRepository.AddAsync(saledImage);

        return addedSaledImage;
    }

    public async Task<SaledImage> UpdateAsync(SaledImage saledImage)
    {
        SaledImage updatedSaledImage = await _saledImageRepository.UpdateAsync(saledImage);

        return updatedSaledImage;
    }

    public async Task<SaledImage> DeleteAsync(SaledImage saledImage, bool permanent = false)
    {
        SaledImage deletedSaledImage = await _saledImageRepository.DeleteAsync(saledImage);

        return deletedSaledImage;
    }
}
