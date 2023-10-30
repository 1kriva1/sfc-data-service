using System.Runtime.Serialization;

using AutoMapper;
using AutoMapper.Internal;

using SFC.Data.Application.Common.Mappings;
using SFC.Data.Application.Features.Data.Queries.GetAll;
using SFC.Data.Application.Models.Data.Common;
using SFC.Data.Application.Models.Data.GetAll;
using SFC.Data.Domain.Common;
using SFC.Data.Domain.Entities;

namespace SFC.Data.Application.UnitTests.Common.Mappings;
public class MappingTests
{
    private readonly IConfigurationProvider _configuration;
    private readonly IMapper _mapper;

    public MappingTests()
    {
        _configuration = new MapperConfiguration(config =>
        {
            config.Internal().AllowAdditiveTypeMapCreation = true;
            config.AddProfile<MappingProfile>();
        });

        _mapper = _configuration.CreateMapper();
    }

    [Fact]
    [Trait("Mapping", "Profile")]
    public void Mapping_Profile_ShouldHaveValidConfiguration()
    {
        // Assert
        _configuration.AssertConfigurationIsValid();
    }

    [Theory]
    [Trait("Mapping", "GetAll")]
    [InlineData(typeof(GetAllViewModel), typeof(GetAllResponse))]
    [InlineData(typeof(BaseDataEntity), typeof(DataValueDto))]
    [InlineData(typeof(FootballPosition), typeof(DataValueDto))]
    [InlineData(typeof(GameStyle), typeof(DataValueDto))]
    [InlineData(typeof(StatCategory), typeof(DataValueDto))]
    [InlineData(typeof(StatSkill), typeof(DataValueDto))]
    [InlineData(typeof(StatType), typeof(StatTypeDataValueDto))]
    [InlineData(typeof(WorkingFoot), typeof(DataValueDto))]
    public void Mapping_GetPlayerByUser_ShouldHaveValidConfiguration(Type source, Type destination)
    {
        // Arrange
        object instance = GetInstanceOf(source);

        // Assert
        _mapper.Map(instance, source, destination);
    }

    private static object GetInstanceOf(Type type)
    {
        if (type.GetConstructor(Type.EmptyTypes) != null)
            return Activator.CreateInstance(type)!;

        if (type == typeof(string))
            return string.Empty;

        // Type without parameterless constructor
        return FormatterServices.GetUninitializedObject(type);
    }
}
