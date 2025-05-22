using SFC.Data.Application.Interfaces.Cache;
using SFC.Data.Application.Interfaces.Persistence.Repository.Data;
using SFC.Data.Domain.Entities.Data;
using SFC.Data.Infrastructure.Persistence.Contexts;
using SFC.Data.Infrastructure.Persistence.Repositories.Common;

namespace SFC.Data.Infrastructure.Persistence.Repositories.Data.Cache;
public class ShirtCacheRepository(ShirtRepository repository, ICache cache)
    : CacheRepository<Shirt, DataDbContext, ShirtEnum>(repository, cache), IShirtRepository
{ }