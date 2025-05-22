using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Data.Domain.Entities.Data;
using SFC.Data.Infrastructure.Persistence.Configurations.Base;

namespace SFC.Data.Infrastructure.Persistence.Configurations.Data;
public class StatSkillConfiguration : EnumDataEntityConfiguration<StatSkill, StatSkillEnum>
{
    public override void Configure(EntityTypeBuilder<StatSkill> builder)
    {
        builder.HasMany(e => e.Types)
               .WithOne()
               .HasForeignKey(t => t.SkillId)
               .IsRequired(true);

        base.Configure(builder);
    }
}