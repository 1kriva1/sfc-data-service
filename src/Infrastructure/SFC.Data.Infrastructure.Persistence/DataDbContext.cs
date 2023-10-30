using System.Reflection;

using MediatR;

using Microsoft.EntityFrameworkCore;

using SFC.Data.Application.Common.Constants;
using SFC.Data.Application.Interfaces.Common;
using SFC.Data.Application.Interfaces.Persistence;
using SFC.Data.Domain.Entities;
using SFC.Data.Infrastructure.Persistence.Extensions;
using SFC.Data.Infrastructure.Persistence.Interceptors;
using SFC.Data.Infrastructure.Persistence.Seeds.Data;

namespace SFC.Data.Infrastructure.Persistence;

public class DataDbContext : DbContext, IDataDbContext
{
    private readonly IMediator _mediator;
    private readonly IDateTimeService _dateTimeService;
    private readonly DataEntitySaveChangesInterceptor _dataEntitySaveChangesInterceptor;

    public DataDbContext(
        DbContextOptions<DataDbContext> options,
        IMediator mediator,
        IDateTimeService dateTimeService,
        DataEntitySaveChangesInterceptor dataEntitySaveChangesInterceptor)
        : base(options)
    {
        _mediator = mediator;
        _dateTimeService = dateTimeService;
        _dataEntitySaveChangesInterceptor = dataEntitySaveChangesInterceptor;
    }

    public DbSet<GameStyle> GameStyles => Set<GameStyle>();

    public DbSet<FootballPosition> FootballPositions => Set<FootballPosition>();

    public DbSet<StatCategory> StatCategories => Set<StatCategory>();

    public DbSet<StatType> StatTypes => Set<StatType>();

    public DbSet<StatSkill> StatSkills => Set<StatSkill>();

    public DbSet<WorkingFoot> WorkingFoots => Set<WorkingFoot>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema(DbConstants.DEFAULT_SCHEMA_NAME);

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        builder.SeedData(_dateTimeService);

        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_dataEntitySaveChangesInterceptor);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEvents(this);

        return await base.SaveChangesAsync(cancellationToken);
    }
}
