using SFC.Data.Application.Interfaces.Persistence.Repository.Data;
using SFC.Data.Domain.Entities.Data;
using SFC.Data.Infrastructure.Persistence.Contexts;
using SFC.Data.Infrastructure.Persistence.Repositories.Common;

namespace SFC.Data.Infrastructure.Persistence.Repositories.Data;
public class StatSkillRepository(DataDbContext context)
    : Repository<StatSkill, DataDbContext, StatSkillEnum>(context), IStatSkillRepository
{ }