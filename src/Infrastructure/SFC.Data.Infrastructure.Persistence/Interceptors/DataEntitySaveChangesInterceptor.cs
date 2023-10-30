using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

using SFC.Data.Application.Interfaces.Common;
using SFC.Data.Domain.Common;
using SFC.Data.Infrastructure.Persistence.Extensions;

namespace SFC.Data.Infrastructure.Persistence.Interceptors;
public class DataEntitySaveChangesInterceptor : SaveChangesInterceptor
{
    private readonly IDateTimeService _dateTimeService;

    public DataEntitySaveChangesInterceptor(IDateTimeService dateTimeService)
    {
        _dateTimeService = dateTimeService;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public void UpdateEntities(DbContext? context)
    {
        if (context == null) return;

        context.ChangeTracker.Entries<BaseDataEntity>().SetAuditable(_dateTimeService);
    }
}