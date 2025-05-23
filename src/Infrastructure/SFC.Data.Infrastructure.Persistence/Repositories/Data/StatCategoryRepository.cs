using SFC.Data.Application.Interfaces.Persistence.Repository.Data;
using SFC.Data.Domain.Entities.Data;
using SFC.Data.Infrastructure.Persistence.Contexts;
using SFC.Data.Infrastructure.Persistence.Repositories.Common;

namespace SFC.Data.Infrastructure.Persistence.Repositories.Data;
public class StatCategoryRepository(DataDbContext context)
    : Repository<StatCategory, DataDbContext, StatCategoryEnum>(context), IStatCategoryRepository
{ }