//using Microsoft.Extensions.Localization;

//using Moq;

//using SFC.Data.Application.Common.Constants;

//namespace SFC.Data.Application.UnitTests.Common.Constants;
//public class MessagesTests
//{
//    private readonly Mock<IStringLocalizer<Resources>> _localizerMock = new();

//    public MessagesTests()
//    {
//        Localization.Configure(_localizerMock.Object);
//    }

//    [Fact]
//    [Trait("Constant", "Messages")]
//    public void Constants_Messages_ShouldReturnExistingTranslation()
//    {
//        // Arrange
//        string localizedValue = "This is success result.";
//        LocalizedString localizedString = new(nameof(Localization.SuccessResult), localizedValue);
//        _localizerMock.Setup(_ => _[nameof(Localization.SuccessResult)]).Returns(localizedString);

//        // Assert
//        Assert.Equal(localizedValue, Localization.SuccessResult);
//    }

//    [Fact]
//    [Trait("Constant", "Messages")]
//    public void Constants_Messages_ShouldReturnDefaultTranslation()
//    {
//        // Assert
//        Assert.Equal("Success result.", Localization.SuccessResult);
//    }

//    [Fact]
//    [Trait("Constant", "Messages")]
//    public void Constants_Messages_ShouldReturnDefaultTranslationWhenNotFound()
//    {
//        // Arrange
//        string localizedValue = "This is success result.";
//        LocalizedString localizedString = new("Key", localizedValue, true);
//        _localizerMock.Setup(_ => _[nameof(Localization.SuccessResult)]).Returns(localizedString);

//        // Assert
//        Assert.Equal("Success result.", Localization.SuccessResult);
//    }

//    [Fact(Skip = "TODO: understand why sometimes it fail")]
//    [Trait("Constant", "Messages")]
//    public void Constants_Messages_ShouldReturnDataValueTranslation()
//    {
//        // Arrange
//        string name = "Defender";
//        string localizedValue = "Захисник";
//        LocalizedString localizedString = new(name, localizedValue);
//        _localizerMock.Setup(_ => _[name]).Returns(localizedString);

//        // Assert
//        Assert.Equal(localizedValue, Localization.GetDataValue(name));
//    }

//    [Fact]
//    [Trait("Constant", "Messages")]
//    public void Constants_Messages_ShouldReturnDefaultDataValueTranslation()
//    {
//        // Arrange
//        string name = "Defender";
//        string localizedValue = "Захисник";
//        LocalizedString localizedString = new(name, localizedValue);
//        _localizerMock.Setup(_ => _["Forward"]).Returns(localizedString);

//        // Assert
//        Assert.Equal(name, Localization.GetDataValue(name));
//    }
//}