using SFC.Data.Messages.Models;
using SFC.Data.Messages.Models.Common;
using SFC.Data.Domain.Common;
using SFC.Data.Domain.Entities;
using SFC.Data.Infrastructure.Extensions;

namespace SFC.Data.Infrastructure.UnitTests.Extensions;
public class MessageExtensionsTests
{
    [Fact]
    [Trait("Extension", "Message")]
    public void Extension_Message_ShouldMapToDataValue()
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
    [Trait("Extension", "Message")]
    public void Extension_Message_ShouldMapToStatTypeDataValue()
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
