using Microsoft.EntityFrameworkCore;

using SFC.Data.Domain.Entities.Metadata;
using SFC.Data.Infrastructure.Persistence.Extensions;

namespace SFC.Data.Infrastructure.Persistence.Seeds;
public static class MetadataSeed
{
    public static void SeedMetadata(this ModelBuilder builder)
    {
        builder.SeedEnumValues<MetadataService, MetadataServiceEnum>(@enum => new MetadataService(@enum));

        builder.SeedEnumValues<MetadataType, MetadataTypeEnum>(@enum => new MetadataType(@enum));

        builder.SeedEnumValues<MetadataState, MetadataStateEnum>(@enum => new MetadataState(@enum));

        builder.SeedEnumValues<MetadataDomain, MetadataDomainEnum>(@enum => new MetadataDomain(@enum));

        List<MetadataEntity> metadata = [
            new MetadataEntity { Service = MetadataServiceEnum.Data, Domain = MetadataDomainEnum.Data, Type = MetadataTypeEnum.Initialization, State = MetadataStateEnum.Required }
        ];

        builder.Entity<MetadataEntity>().HasData(metadata);
    }
}