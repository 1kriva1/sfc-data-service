using SFC.Data.Contracts.Models;
using SFC.Data.Contracts.Models.Common;
using SFC.Data.Domain.Common;
using SFC.Data.Domain.Entities;
using SFC.Data.Infrastructure.Extensions;

namespace SFC.Data.Infrastructure.UnitTests.Extensions;
public class EventsExtensionsTests
{
    [Fact]
    [Trait("Extension", "Events")]
    public void Extension_Events_ShouldMapToDataValue()
    {
        // Arrange
        BaseDataEntity entity = new() { Id = 0, Title = "Title" };

        // Act
        DataValue value = entity.MapToDataValue();

        // Assert
        Assert.Equal(value.Id, entity.Id);
        Assert.Equal(value.Title, entity.Title);
    }

    [Fact]
    [Trait("Extension", "Events")]
    public void Extension_Events_ShouldMapToStatTypeDataValue()
    {
        // Arrange
        StatType entity = new() { Id = 0, Title = "Title", CategoryId = 1, SkillId = 2 };

        // Act
        StatTypeDataValue value = entity.MapToDataValue();

        // Assert
        Assert.Equal(value.Id, value.Id);
        Assert.Equal(value.Title, value.Title);
        Assert.Equal(value.CategoryId, value.CategoryId);
        Assert.Equal(value.SkillId, value.SkillId);
    }
}
