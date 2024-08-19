using Garden.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Text;
using System.Text.Json;

namespace Garden.Tests;

public class Garden_CreateGardenTest
{
    private readonly Mock<ICreateGardenService> _mockService;
    private readonly Mock<ILogger<CreateGarden>> _mockLogger;
    private readonly CreateGarden _function;

    public Garden_CreateGardenTest()
    {
        _mockService = new Mock<ICreateGardenService>();
        _mockLogger = new Mock<ILogger<CreateGarden>>();
        _function = new CreateGarden(_mockLogger.Object, _mockService.Object);
    }

    [Fact]
    public async Task Run_InvalidRequest_ReturnsBadRequest()
    {
        // Arrange
        var mockRequest = new Mock<HttpRequest>();
        _mockService.Setup(s => s.GetDtoFromBodyAsync(It.IsAny<HttpRequest>())).ReturnsAsync((CreateGardenRequestDTO)null);

        // Act
        var result = await _function.Run(mockRequest.Object);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("batRequest", badRequestResult.Value);
    }


    [Fact]
    public async Task Run_ValidRequest_ReturnsOkResponse()
    {
        // Arrange
        var validRequestDTO = new CreateGardenRequestDTO
        {
            UserId = 1,
            Name = "New Garden",
            Location = "Test Location",
            Size = 100,
            ImagePath = "/images/garden.jpg"
        };

        var mockRequest = new Mock<HttpRequest>();
        mockRequest.Setup(r => r.Body).Returns(new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(validRequestDTO))));

        _mockService.Setup(s => s.GetDtoFromBodyAsync(It.IsAny<HttpRequest>())).ReturnsAsync(validRequestDTO);
        _mockService.Setup(s => s.IsValid(It.IsAny<DTO>())).Returns(true);
        _mockService.Setup(s => s.CreateGarden(It.IsAny<CreateGardenRequestDTO>())).ReturnsAsync(new Models.Garden { GardenId = 1, Name = "test", Location="testLocation", Size= 0.1 });
        _mockService.Setup(s => s.GetResponseDTO(It.IsAny<Models.Garden>())).Returns(new CreateGardenResponseDTO { GardenId = 1, Message = "Garden created successfully." });

        // Act
        var result = await _function.Run(mockRequest.Object);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<CreateGardenResponseDTO>(okResult.Value);
        Assert.Equal(1, returnValue.GardenId);
        Assert.Equal("Garden created successfully.", returnValue.Message);
    }
}