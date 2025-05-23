//using System.Text.Json;

//using AutoMapper;

//using SFC.Data.Application.Common.Mappings;
//using SFC.Data.Application.Features.Data.Queries.GetAll;
//using SFC.Data.Application.Features.Data.Queries.GetAll.Dto;
//using SFC.Data.Domain.Common;
//using SFC.Data.Domain.Entities;

//namespace SFC.Data.Application.UnitTests.Common.Mappings;
//public class MappingTests
//{
//    private readonly MapperConfiguration _configuration;
//    private readonly IMapper _mapper;

//    public MappingTests()
//    {
//        _configuration = new MapperConfiguration(config => config.AddProfile<MappingProfile>());
//        _mapper = _configuration.CreateMapper();
//    }

//    [Fact]
//    [Trait("Mapping", "Profile")]
//    public void Mapping_Profile_ShouldHaveValidConfiguration()
//    {
//        // Assert
//        _configuration.AssertConfigurationIsValid();
//    }

//    [Theory]
//    [Trait("Mapping", "Models")]
//    [InlineData(typeof(BaseDataEnumEntity), typeof(DataValueDto))]
//    [InlineData(typeof(FootballPosition), typeof(DataValueDto))]
//    [InlineData(typeof(GameStyle), typeof(DataValueDto))]
//    [InlineData(typeof(StatCategory), typeof(DataValueDto))]
//    [InlineData(typeof(StatSkill), typeof(DataValueDto))]
//    [InlineData(typeof(StatType), typeof(StatTypeDataValueDto))]
//    [InlineData(typeof(WorkingFoot), typeof(DataValueDto))]
//    public void Mapping_Models_ShouldHaveValidConfiguration(Type source, Type destination)
//    {
//        // Arrange
//        object? instance = GetInstanceOf(source);

//        // Assert
//        _mapper.Map(instance, source, destination);
//    }

//    private static object? GetInstanceOf(Type type)
//    {
//        if (type.GetConstructor(Type.EmptyTypes) != null)
//            return Activator.CreateInstance(type)!;

//        if (type == typeof(string))
//            return string.Empty;

//        string json = JsonSerializer.Serialize(type);
//        return JsonSerializer.Deserialize<object>(json);
//    }
//}