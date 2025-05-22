using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Data.Domain.Entities.Data;
using SFC.Data.Infrastructure.Persistence.Configurations.Base;

namespace SFC.Data.Infrastructure.Persistence.Configurations.Data;
public class StatCategoryConfiguration : EnumDataEntityConfiguration<StatCategory, StatCategoryEnum>
{
    public override void Configure(EntityTypeBuilder<StatCategory> builder)
    {
        builder.HasMany(e => e.Types)
               .WithOne()
               .HasForeignKey(t => t.CategoryId)
               .IsRequired(true);

        base.Configure(builder);
    }
}