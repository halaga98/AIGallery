using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SaledImages;

public interface ISaledImagesService
{
    Task<SaledImage?> GetAsync(
        Expression<Func<SaledImage, bool>> predicate,
        Func<IQueryable<SaledImage>, IIncludableQueryable<SaledImage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<SaledImage>?> GetListAsync(
        Expression<Func<SaledImage, bool>>? predicate = null,
        Func<IQueryable<SaledImage>, IOrderedQueryable<SaledImage>>? orderBy = null,
        Func<IQueryable<SaledImage>, IIncludableQueryable<SaledImage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<SaledImage> AddAsync(SaledImage saledImage);
    Task<SaledImage> UpdateAsync(SaledImage saledImage);
    Task<SaledImage> DeleteAsync(SaledImage saledImage, bool permanent = false);
}
