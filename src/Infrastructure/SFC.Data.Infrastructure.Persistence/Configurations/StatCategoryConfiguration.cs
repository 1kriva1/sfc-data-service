using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Data.Domain.Entities;

namespace SFC.Data.Infrastructure.Persistence.Configurations;
public class StatCategoryConfiguration : BaseDataEntityConfiguration<StatCategory>
{
    public override void Configure(EntityTypeBuilder<StatCategory> builder)
    {
        builder.HasMany(e => e.Types)
               .WithOne()
               .HasForeignKey(t=>t.CategoryId)
               .IsRequired(true);

        base.Configure(builder);
    }
}
