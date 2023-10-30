using SFC.Data.Domain.Common;
using SFC.Data.Domain.Entities;
using SFC.Data.Contracts.Models;
using SFC.Data.Contracts.Models.Common;

namespace SFC.Data.Infrastructure.Extensions;
public static class EventsExtensions
{
    public static DataValue MapToDataValue(this BaseDataEntity entity)
        => new() { Id = entity.Id, Title = entity.Title };

    public static StatTypeDataValue MapToDataValue(this StatType entity)
        => new() { Id = entity.Id, Title = entity.Title, CategoryId = entity.CategoryId, SkillId = entity.SkillId };
}
