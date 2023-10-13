using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ArtStyles;

public class ArtStylesManager : IArtStylesService
{
    private readonly IArtStyleRepository _artStyleRepository;
 
    public ArtStylesManager(IArtStyleRepository artStyleRepository)
    {
        _artStyleRepository = artStyleRepository;
     }

    public async Task<ArtStyle?> GetAsync(
        Expression<Func<ArtStyle, bool>> predicate,
        Func<IQueryable<ArtStyle>, IIncludableQueryable<ArtStyle, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ArtStyle? artStyle = await _artStyleRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return artStyle;
    }

    public async Task<IPaginate<ArtStyle>?> GetListAsync(
        Expression<Func<ArtStyle, bool>>? predicate = null,
        Func<IQueryable<ArtStyle>, IOrderedQueryable<ArtStyle>>? orderBy = null,
        Func<IQueryable<ArtStyle>, IIncludableQueryable<ArtStyle, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ArtStyle> artStyleList = await _artStyleRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return artStyleList;
    }

    public async Task<ArtStyle> AddAsync(ArtStyle artStyle)
    {
        ArtStyle addedArtStyle = await _artStyleRepository.AddAsync(artStyle);

        return addedArtStyle;
    }

    public async Task<ArtStyle> UpdateAsync(ArtStyle artStyle)
    {
        ArtStyle updatedArtStyle = await _artStyleRepository.UpdateAsync(artStyle);

        return updatedArtStyle;
    }

    public async Task<ArtStyle> DeleteAsync(ArtStyle artStyle, bool permanent = false)
    {
        ArtStyle deletedArtStyle = await _artStyleRepository.DeleteAsync(artStyle);

        return deletedArtStyle;
    }
}
