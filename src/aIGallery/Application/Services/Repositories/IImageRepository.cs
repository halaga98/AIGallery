using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IImageRepository : IAsyncRepository<Image, Guid>, IRepository<Image, Guid>
{
}