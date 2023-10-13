using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ArtStyleRepository : EfRepositoryBase<ArtStyle, Guid, BaseDbContext>, IArtStyleRepository
{
    public ArtStyleRepository(BaseDbContext context) : base(context)
    {
    }
}