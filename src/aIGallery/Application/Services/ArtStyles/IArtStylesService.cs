using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ArtStyles;

public interface IArtStylesService
{
    Task<ArtStyle?> GetAsync(
        Expression<Func<ArtStyle, bool>> predicate,
        Func<IQueryable<ArtStyle>, IIncludableQueryable<ArtStyle, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ArtStyle>?> GetListAsync(
        Expression<Func<ArtStyle, bool>>? predicate = null,
        Func<IQueryable<ArtStyle>, IOrderedQueryable<ArtStyle>>? orderBy = null,
        Func<IQueryable<ArtStyle>, IIncludableQueryable<ArtStyle, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ArtStyle> AddAsync(ArtStyle artStyle);
    Task<ArtStyle> UpdateAsync(ArtStyle artStyle);
    Task<ArtStyle> DeleteAsync(ArtStyle artStyle, bool permanent = false);
}
