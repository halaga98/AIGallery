using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IArtStyleRepository : IAsyncRepository<ArtStyle, Guid>, IRepository<ArtStyle, Guid>
{
}