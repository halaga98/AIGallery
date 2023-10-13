using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISaledImageRepository : IAsyncRepository<SaledImage, Guid>, IRepository<SaledImage, Guid>
{
}