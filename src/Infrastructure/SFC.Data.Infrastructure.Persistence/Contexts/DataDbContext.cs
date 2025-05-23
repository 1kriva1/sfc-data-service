using System.Reflection;
using System.Reflection.Emit;

using Microsoft.EntityFrameworkCore;

using SFC.Data.Application.Interfaces.Common;
using SFC.Data.Application.Interfaces.Persistence.Context;
using SFC.Data.Domain.Entities.Data;
using SFC.Data.Infrastructure.Persistence.Constants;
using SFC.Data.Infrastructure.Persistence.Interceptors;
using SFC.Data.Infrastructure.Persistence.Seeds;

namespace SFC.Data.Infrastructure.Persistence.Contexts;

public class DataDbContext(
    DbContextOptions<DataDbContext> options,
    IDateTimeService dateTimeService,
    DataEntitySaveChangesInterceptor dataEntityInterceptor,
    DispatchDomainEventsSaveChangesInterceptor eventsInterceptor)
    : BaseDbContext<DataDbContext>(options, eventsInterceptor), IDataDbContext
{
    private readonly IDateTimeService _dateTimeService = dateTimeService;
    private readonly DataEntitySaveChangesInterceptor _dataEntityInterceptor = dataEntityInterceptor;

    public IQueryable<GameStyle> GameStyles => Set<GameStyle>();

    public IQueryable<FootballPosition> FootballPositions => Set<FootballPosition>();

    public IQueryable<StatCategory> StatCategories => Set<StatCategory>();

    public IQueryable<StatType> StatTypes => Set<StatType>();

    public IQueryable<StatSkill> StatSkills => Set<StatSkill>();

    public IQueryable<WorkingFoot> WorkingFoots => Set<WorkingFoot>();

    public IQueryable<Shirt> Shirts => Set<Shirt>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        modelBuilder.HasDefaultSchema(DatabaseConstants.DefaultSchemaName);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        MetadataDbContext.ApplyMetadataConfigurations(modelBuilder);

        modelBuilder.SeedData(_dateTimeService);

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_dataEntityInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}