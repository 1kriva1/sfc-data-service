using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using SFC.Data.Infrastructure.Persistence.Configurations;
using SFC.Data.Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SFC.Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SFC.Data.Application.Common.Constants;

namespace SFC.Data.Infrastructure.Persistence.UnitTests.Configurations;
public class ConfigurationTests
{
    [Fact]
    [Trait("Persistence", "Configuration")]
    public void Persistence_Configuration_FootballPosition_ShouldHaveCorrectConfiguration()
    {
        // Arrange
        FootballPositionConfiguration sut = new();
        EntityTypeBuilder<FootballPosition> builder = GetEntityBuilder<FootballPosition>();

        // Act
        sut.Configure(builder);

        // Assert
        AssertBaseDataEntity(builder);
    }

    [Fact]
    [Trait("Persistence", "Configuration")]
    public void Persistence_Configuration_GameStyle_ShouldHaveCorrectConfiguration()
    {
        // Arrange
        GameStyleConfiguration sut = new();
        EntityTypeBuilder<GameStyle> builder = GetEntityBuilder<GameStyle>();

        // Act
        sut.Configure(builder);

        // Assert
        AssertBaseDataEntity(builder);
    }

    [Fact]
    [Trait("Persistence", "Configuration")]
    public void Persistence_Configuration_StatCategory_ShouldHaveCorrectConfiguration()
    {
        // Arrange
        StatCategoryConfiguration sut = new();
        EntityTypeBuilder<StatCategory> builder = GetEntityBuilder<StatCategory>();

        // Act
        sut.Configure(builder);

        // Assert
        AssertBaseDataEntity(builder);
    }

    [Fact]
    [Trait("Persistence", "Configuration")]
    public void Persistence_Configuration_StatSkill_ShouldHaveCorrectConfiguration()
    {
        // Arrange
        StatSkillConfiguration sut = new();
        EntityTypeBuilder<StatSkill> builder = GetEntityBuilder<StatSkill>();

        // Act
        sut.Configure(builder);

        // Assert
        AssertBaseDataEntity(builder);
    }

    [Fact]
    [Trait("Persistence", "Configuration")]
    public void Persistence_Configuration_StatType_ShouldHaveCorrectConfiguration()
    {
        // Arrange
        StatTypeConfiguration sut = new();
        EntityTypeBuilder<StatType> builder = GetEntityBuilder<StatType>();

        // Act
        sut.Configure(builder);

        // Assert
        AssertBaseDataEntity(builder);
    }

    [Fact]
    [Trait("Persistence", "Configuration")]
    public void Persistence_Configuration_WorkingFoot_ShouldHaveCorrectConfiguration()
    {
        // Arrange
        WorkingFootConfiguration sut = new();
        EntityTypeBuilder<WorkingFoot> builder = GetEntityBuilder<WorkingFoot>();

        // Act
        sut.Configure(builder);

        // Assert
        AssertBaseDataEntity(builder);
    }

    private static void AssertBaseDataEntity<T>(EntityTypeBuilder<T> builder) where T : BaseDataEntity
    {
        IEnumerable<IMutableProperty> properties = builder.Metadata.GetDeclaredProperties();

        Assert.Equal(3, properties.Count());

        IMutableProperty idProperty = properties.FirstOrDefault(m => m.Name == nameof(BaseDataEntity.Id))!;
        Assert.True(idProperty.IsKey());
        Assert.False(idProperty.IsColumnNullable());
        Assert.Equal(0, idProperty.GetColumnOrder());
        Assert.Equal(ValueGenerated.Never, idProperty.ValueGenerated);
        Assert.Equal(nameof(BaseDataEntity.Id), idProperty.Name);

        IMutableProperty titleProperty = properties.FirstOrDefault(m => m.Name == nameof(BaseDataEntity.Title))!;
        Assert.False(titleProperty.IsColumnNullable());
        Assert.Equal(DatabaseConstants.TITLE_VALUE_MAX_LENGTH, titleProperty.GetMaxLength());

        IMutableProperty createdDateProperty = properties.FirstOrDefault(m => m.Name == nameof(BaseDataEntity.CreatedDate))!;
        Assert.False(createdDateProperty.IsColumnNullable());
        Assert.Equal(1, createdDateProperty.GetColumnOrder());

        Assert.Equal(typeof(T).Name, builder.Metadata.GetTableName());
    }

    private static EntityTypeBuilder<T> GetEntityBuilder<T>() where T : class
    {
#pragma warning disable EF1001 // Internal EF Core API usage.
        EntityType entityType = new(typeof(T).Name, typeof(T), new Model(), false, ConfigurationSource.Explicit);

        EntityTypeBuilder<T> builder = new(entityType);

        return builder;
#pragma warning restore EF1001 // Internal EF Core API usage.
    }
}
