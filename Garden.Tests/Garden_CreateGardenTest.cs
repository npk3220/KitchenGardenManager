using Garden.Create;
using Garden.Update;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Garden.Tests;

public class Garden_CreateGardenTest
{
    [Fact]
    public void CreateGarden_InputIsNon_ReturnOK()
    {
        // Arrange
        var logger = Mock.Of<ILogger<CreateGarden>>();
        var service = Mock.Of<CreateGardenService>();
        var httpRequest = new Mock<HttpRequest>();

        var createGardenFunction = new CreateGarden(logger, service);

        // Act
        var result = createGardenFunction.Run(httpRequest.Object);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, okResult.StatusCode);
        Assert.Equal("Welcome to Azure Functions!", okResult.Value);

    }
}