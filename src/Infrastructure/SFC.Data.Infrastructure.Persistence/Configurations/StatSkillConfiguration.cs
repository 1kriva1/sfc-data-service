using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Data.Domain.Entities;

namespace SFC.Data.Infrastructure.Persistence.Configurations;
public class StatSkillConfiguration : BaseDataEntityConfiguration<StatSkill>
{
    public override void Configure(EntityTypeBuilder<StatSkill> builder)
    {
        builder.HasMany(e => e.Types)
               .WithOne()
               .HasForeignKey(t=>t.SkillId)
               .IsRequired(true);

        base.Configure(builder);
    }
}
