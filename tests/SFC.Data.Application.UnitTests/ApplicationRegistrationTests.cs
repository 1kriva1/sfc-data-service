//using AutoMapper;

//using MediatR;

//using Microsoft.Extensions.DependencyInjection;

//using SFC.Data.Application.Common.Behaviours;
//using SFC.Data.Application.Features.Data.Queries.GetAll;

//namespace SFC.Data.Application.UnitTests;
//public class ApplicationRegistrationTests
//{
//    [Fact]
//    [Trait("Registration", "Servises")]
//    public void ApplicationRegistration_Execute_ServicesAreRegistered()
//    {
//        // Arrange
//        ServiceCollection serviceCollection = new();

//        // Act
//        serviceCollection.AddApplicationServices();
//        ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

//        // Assert
//        Assert.NotNull(serviceProvider.GetService<IMediator>());
//        Assert.NotNull(serviceProvider.GetService<IMapper>());
//        Assert.NotNull(serviceCollection.FirstOrDefault(s => s.ImplementationType == typeof(UnhandledExceptionBehaviour<,>)));
//        Assert.NotNull(serviceCollection.FirstOrDefault(s => s.ImplementationType == typeof(LoggingBehaviour<,>)));
//        Assert.NotNull(serviceCollection.FirstOrDefault(s => s.ImplementationType == typeof(PerformanceBehaviour<,>)));
//        Assert.NotNull(serviceCollection.FirstOrDefault(s => s.ImplementationType == typeof(GetAllQueryHandler)));
//    }
//}