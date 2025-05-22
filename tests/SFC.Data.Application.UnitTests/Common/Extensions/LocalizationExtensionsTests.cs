//using Microsoft.Extensions.Localization;

//using Moq;

//using SFC.Data.Application.Common.Constants;
//using SFC.Data.Application.Common.Extensions;
//using SFC.Data.Application.Features.Data.Queries.GetAll.Dto;
//using SFC.Data.Domain.Common;

//namespace SFC.Data.Application.UnitTests.Common.Extensions;
//public class LocalizationExtensionsTests
//{
//    [Fact(Skip = "TODO: understand why sometimes it fail")]
//    [Trait("Extension", "Localization")]
//    public void Extension_Localization_ShouldLocalizeDataValue()
//    {
//        // Arrange
//        string name = "Midfielder", localizedValue = "Півзахисник";
//        Mock<IStringLocalizer<Resources>> _localizerMock = new();
//        LocalizedString localizedString = new(name, localizedValue);
//        _localizerMock.Setup(_ => _[name]).Returns(localizedString);
//        Localization.Configure(_localizerMock.Object);

//        BaseDataEnumEntity value = new() { Title = name };

//        // Act
//        value.Localize();

//        // Assert
//        Assert.Equal(localizedValue, value.Title);
//    }

//    [Fact(Skip = "TODO: understand why sometimes it fail")]
//    [Trait("Extension", "Localization")]
//    public void Extension_Localization_ShouldLocalizeDataValues()
//    {
//        // Arrange
//        Mock<IStringLocalizer<Resources>> _localizerMock = new();
//        _localizerMock.Setup(_ => _["Midfielder"]).Returns(new LocalizedString("Midfielder", "Півзахисник"));
//        _localizerMock.Setup(_ => _["Goalkeeper"]).Returns(new LocalizedString("Goalkeeper", "Воротар"));
//        Localization.Configure(_localizerMock.Object);

//        IEnumerable<BaseDataEnumEntity> values = new List<BaseDataEnumEntity> {
//            new() { Title = "Midfielder" },
//            new() { Title = "Goalkeeper" }
//        };

//        // Act
//        IEnumerable<BaseDataEnumEntity> result = values.Localize();

//        // Assert
//        Assert.Equal(2, result.Count());
//        BaseDataEnumEntity[] array = result.ToArray();
//        Assert.Equal("Півзахисник", array[0].Title);
//        Assert.Equal("Воротар", array[1].Title);
//    }
//}