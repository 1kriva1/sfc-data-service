using Microsoft.EntityFrameworkCore;

using SFC.Data.Application.Interfaces.Common;
using SFC.Data.Domain.Common;
using SFC.Data.Domain.Entities;

namespace SFC.Data.Infrastructure.Persistence.Seeds.Data;
public static class DataSeed
{
    public static void SeedData(this ModelBuilder builder, IDateTimeService dateTimeService)
    {
        List<BaseDataEntity> footballPositions = new() {
            new FootballPosition { Id = 0, Title = "Goalkeeper" },
            new FootballPosition { Id = 1, Title = "Defender" },
            new FootballPosition { Id = 2, Title = "Midfielder" },
            new FootballPosition { Id = 3, Title = "Forward" }
        };
        footballPositions.ForEach(t => t.CreatedDate = dateTimeService.Now);
        builder.Entity<FootballPosition>().HasData(footballPositions);

        List<BaseDataEntity> gameStyles = new() {
            new GameStyle { Id = 0, Title = "Defend" },
            new GameStyle { Id = 1, Title = "Attacking" },
            new GameStyle { Id = 2, Title = "Aggressive" },
            new GameStyle { Id = 3, Title = "Control" },
            new GameStyle { Id = 4, Title = "CounterAttacks" }
        };
        gameStyles.ForEach(t => t.CreatedDate = dateTimeService.Now);
        builder.Entity<GameStyle>().HasData(gameStyles);

        List<BaseDataEntity> workingFoots = new() {
            new WorkingFoot { Id = 0, Title = "Right" },
            new WorkingFoot { Id = 1, Title = "Left" },
            new WorkingFoot { Id = 2, Title = "Both" }
        };
        workingFoots.ForEach(t => t.CreatedDate = dateTimeService.Now);
        builder.Entity<WorkingFoot>().HasData(workingFoots);

        List<BaseDataEntity> statCategories = new() {
            new StatCategory { Id = 0, Title = "Pace" },
            new StatCategory { Id = 1, Title = "Shooting" },
            new StatCategory { Id = 2, Title = "Passing" },
            new StatCategory { Id = 3, Title = "Dribbling" },
            new StatCategory { Id = 4, Title = "Defending" },
            new StatCategory { Id = 5, Title = "Physicality" }
        };
        statCategories.ForEach(t => t.CreatedDate = dateTimeService.Now);
        builder.Entity<StatCategory>().HasData(statCategories);

        List<BaseDataEntity> statSkills = new() {
            new StatSkill { Id = 0, Title = "Physical" },
            new StatSkill { Id = 1, Title = "Mental" },
            new StatSkill { Id = 2, Title = "Skill" }
        };
        statSkills.ForEach(t => t.CreatedDate = dateTimeService.Now);
        builder.Entity<StatSkill>().HasData(statSkills);

        List<BaseDataEntity> statTypes = new()
        {
            new StatType { Id = 0, Title = "Acceleration", CategoryId = 0, SkillId = 0 },
            new StatType { Id = 1, Title = "SprintSpeed", CategoryId = 0, SkillId = 0 },
            new StatType { Id = 2, Title = "Positioning", CategoryId = 1, SkillId = 2 },
            new StatType { Id = 3, Title = "Finishing", CategoryId = 1, SkillId = 2 },
            new StatType { Id = 4, Title = "ShotPower", CategoryId = 1, SkillId = 2 },
            new StatType { Id = 5, Title = "LongShots", CategoryId = 1, SkillId = 2 },
            new StatType { Id = 6, Title = "Volleys", CategoryId = 1, SkillId = 2 },
            new StatType { Id = 7, Title = "Penalties", CategoryId = 1, SkillId = 2 },
            new StatType { Id = 8, Title = "Vision", CategoryId = 2, SkillId = 2 },
            new StatType { Id = 9, Title = "Crossing", CategoryId = 2, SkillId = 2 },
            new StatType { Id = 10, Title = "FkAccuracy", CategoryId = 2, SkillId = 2 },
            new StatType { Id = 11, Title = "ShortPassing", CategoryId = 2, SkillId = 2 },
            new StatType { Id = 12, Title = "LongPassing", CategoryId = 2, SkillId = 2 },
            new StatType { Id = 13, Title = "Curve", CategoryId = 2, SkillId = 2 },
            new StatType { Id = 14, Title = "Agility", CategoryId = 3, SkillId = 0 },
            new StatType { Id = 15, Title = "Balance", CategoryId = 3, SkillId = 0},
            new StatType { Id = 16, Title = "Reactions", CategoryId = 3, SkillId = 0 },
            new StatType { Id = 17, Title = "BallControl", CategoryId = 3, SkillId = 2 },
            new StatType { Id = 18, Title = "Dribbling", CategoryId = 3, SkillId = 2 },
            new StatType { Id = 19, Title = "Composure", CategoryId = 3, SkillId = 1 },
            new StatType { Id = 20, Title = "Interceptions", CategoryId = 4, SkillId = 2},
            new StatType { Id = 21, Title = "HeadingAccuracy", CategoryId = 4, SkillId = 2 },
            new StatType { Id = 22, Title = "DefAwarenence", CategoryId = 4, SkillId = 2 },
            new StatType { Id = 23, Title = "StandingTackle", CategoryId = 4, SkillId = 2 },
            new StatType { Id = 24, Title = "SlidingTackle", CategoryId = 4, SkillId = 2 },
            new StatType { Id = 25, Title = "Jumping", CategoryId = 5, SkillId = 0 },
            new StatType { Id = 26, Title = "Stamina", CategoryId = 5, SkillId = 0 },
            new StatType { Id = 27, Title = "Strength", CategoryId = 5, SkillId = 0 },
            new StatType { Id = 28, Title = "Aggression", CategoryId = 5, SkillId = 1 }
        };
        statTypes.ForEach(t => t.CreatedDate = dateTimeService.Now);
        builder.Entity<StatType>().HasData(statTypes);
    }
}
