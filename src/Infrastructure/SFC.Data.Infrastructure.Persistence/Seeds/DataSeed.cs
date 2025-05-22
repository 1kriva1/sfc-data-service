using Microsoft.EntityFrameworkCore;

using SFC.Data.Application.Interfaces.Common;
using SFC.Data.Domain.Entities.Data;
using SFC.Data.Infrastructure.Persistence.Extensions;

namespace SFC.Data.Infrastructure.Persistence.Seeds;
public static class DataSeed
{
    public static void SeedData(this ModelBuilder builder, IDateTimeService dateTimeService)
    {
        builder.SeedDataEnumValues<FootballPosition, FootballPositionEnum>(@enum => new FootballPosition(@enum).SetCreatedDate(dateTimeService));

        builder.SeedDataEnumValues<GameStyle, GameStyleEnum>(@enum => new GameStyle(@enum).SetCreatedDate(dateTimeService));

        builder.SeedDataEnumValues<WorkingFoot, WorkingFootEnum>(@enum => new WorkingFoot(@enum).SetCreatedDate(dateTimeService));

        builder.SeedDataEnumValues<StatCategory, StatCategoryEnum>(@enum => new StatCategory(@enum).SetCreatedDate(dateTimeService));

        builder.SeedDataEnumValues<StatSkill, StatSkillEnum>(@enum => new StatSkill(@enum).SetCreatedDate(dateTimeService));

        builder.SeedDataEnumValues<StatType, StatTypeEnum>(@enum => ConvertStatType(@enum).SetCreatedDate(dateTimeService));

        builder.SeedDataEnumValues<Shirt, ShirtEnum>(@enum => new Shirt(@enum).SetCreatedDate(dateTimeService));
    }

    private static StatType ConvertStatType(StatTypeEnum @enum)
    {
        StatType type = new(@enum);

        switch (type.Id)
        {
            case StatTypeEnum.Acceleration:
            case StatTypeEnum.SprintSpeed:
                type.CategoryId = StatCategoryEnum.Pace;
                type.SkillId = StatSkillEnum.Physical;
                break;
            case StatTypeEnum.Positioning:
            case StatTypeEnum.Finishing:
            case StatTypeEnum.ShotPower:
            case StatTypeEnum.LongShots:
            case StatTypeEnum.Volleys:
            case StatTypeEnum.Penalties:
                type.CategoryId = StatCategoryEnum.Shooting;
                type.SkillId = StatSkillEnum.Skill;
                break;
            case StatTypeEnum.Vision:
            case StatTypeEnum.Crossing:
            case StatTypeEnum.FkAccuracy:
            case StatTypeEnum.ShortPassing:
            case StatTypeEnum.LongPassing:
            case StatTypeEnum.Curve:
                type.CategoryId = StatCategoryEnum.Passing;
                type.SkillId = StatSkillEnum.Skill;
                break;
            case StatTypeEnum.Agility:
            case StatTypeEnum.Balance:
            case StatTypeEnum.Reactions:
                type.CategoryId = StatCategoryEnum.Dribbling;
                type.SkillId = StatSkillEnum.Physical;
                break;
            case StatTypeEnum.BallControl:
            case StatTypeEnum.Dribbling:
                type.CategoryId = StatCategoryEnum.Dribbling;
                type.SkillId = StatSkillEnum.Skill;
                break;
            case StatTypeEnum.Composure:
                type.CategoryId = StatCategoryEnum.Dribbling;
                type.SkillId = StatSkillEnum.Mental;
                break;
            case StatTypeEnum.Interceptions:
            case StatTypeEnum.HeadingAccuracy:
            case StatTypeEnum.DefAwarenence:
            case StatTypeEnum.StandingTackle:
            case StatTypeEnum.SlidingTackle:
                type.CategoryId = StatCategoryEnum.Defending;
                type.SkillId = StatSkillEnum.Skill;
                break;
            case StatTypeEnum.Jumping:
            case StatTypeEnum.Stamina:
            case StatTypeEnum.Strength:
                type.CategoryId = StatCategoryEnum.Physicality;
                type.SkillId = StatSkillEnum.Physical;
                break;
            case StatTypeEnum.Aggression:
                type.CategoryId = StatCategoryEnum.Physicality;
                type.SkillId = StatSkillEnum.Mental;
                break;
        }

        return type;
    }
}