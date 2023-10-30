using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using SFC.Data.Application.Interfaces.Common;
using SFC.Data.Domain.Common;

namespace SFC.Data.Infrastructure.Persistence.Extensions;
public static class EntityExtensions
{
    public static void SetAuditable(this IEnumerable<EntityEntry<BaseDataEntity>> entries,
        IDateTimeService dateTimeService)
    {
        foreach (EntityEntry<BaseDataEntity> entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedDate = dateTimeService.Now;
            }
        }
    }
}
