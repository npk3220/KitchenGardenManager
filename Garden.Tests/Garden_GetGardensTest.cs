using Garden.List;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Garden.Tests;

public class Garden_GetGardensTest
{
    private readonly Mock<IGetGardensService> _mockService;
    private readonly Mock<ILogger<GetGardens>> _mockLogger;
    private readonly GetGardens _function;

    public Garden_GetGardensTest()
    {
        _mockService = new Mock<IGetGardensService>();
        _mockLogger = new Mock<ILogger<GetGardens>>();
        _function = new GetGardens(_mockLogger.Object, _mockService.Object);
    }

    [Fact]
    public async Task Run_RequestIsInvalid_ReturnsBadRequest()
    {
        // Arrange
        var mockRequest = new Mock<HttpRequest>();
        _mockService.Setup(s => s.GetDtoFromQuery(It.IsAny<HttpRequest>())).Returns((GetGardensRequestDTO)null);

        // Act
        var result = await _function.Run(mockRequest.Object);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("batRequest", badRequestResult.Value);
    }

    [Fact]
    public async Task Run_RequestIsValid_ReturnsOkObjectResult()
    {
        // Arrange
        var mockRequest = new Mock<HttpRequest>();
        var mockRequestDTO = new GetGardensRequestDTO
        {
            UserName = "TestUser",
            GardenName = "TestGarden"
        };

        var mockGardenList = new List<GetGardensResponseDTO>
        {
            new GetGardensResponseDTO
            {
                GardenId = 1,
                GardenName = "TestGarden",
                Location = "Location1",
                Size = 100,
                ImagePath = "/images/garden1.jpg",
                IsManagementEnded = false,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UserId = 1,
                UserName = "TestUser"
            }
        };

        _mockService.Setup(s => s.GetDtoFromQuery(It.IsAny<HttpRequest>())).Returns(mockRequestDTO);
        _mockService.Setup(s => s.GetGardenListAsync(mockRequestDTO)).ReturnsAsync(mockGardenList);

        // Act
        var result = await _function.Run(mockRequest.Object);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<GetGardensResponseDTO>>(okResult.Value);
        Assert.Single(returnValue);
        Assert.Equal("TestGarden", returnValue.First().GardenName);
        Assert.Equal("TestUser", returnValue.First().UserName);
    }
}