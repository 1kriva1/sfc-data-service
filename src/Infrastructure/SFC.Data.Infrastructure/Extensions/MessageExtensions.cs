using SFC.Data.Domain.Common;
using SFC.Data.Domain.Entities;
using SFC.Data.Messages.Models;
using SFC.Data.Messages.Models.Common;

namespace SFC.Data.Infrastructure.Extensions;
public static class MessageExtensions
{
    public static DataValue MapToDataValue(this BaseDataEntity entity)
        => new() { Id = entity.Id, Title = entity.Title };

    public static StatTypeDataValue MapToDataValue(this StatType entity)
        => new() { Id = entity.Id, Title = entity.Title, CategoryId = entity.CategoryId, SkillId = entity.SkillId };
}
