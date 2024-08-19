// Ignore Spelling: Dto

using Garden.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Models;
using Moq;
using System.Text;
using System.Text.Json;

namespace Garden.Tests
{
    public class Garden_CreateGardenServiceTest
    {
        private readonly Mock<HomeGardenContext> _mockContext;
        private readonly Mock<ILogger<CreateGardenService>> _mockLogger;
        private readonly CreateGardenService _service;

        public Garden_CreateGardenServiceTest()
        {
            _mockContext = new Mock<HomeGardenContext>();
            _mockLogger = new Mock<ILogger<CreateGardenService>>();
            _service = new CreateGardenService(_mockLogger.Object, _mockContext.Object);
        }

        [Fact]
        public async Task GetDtoFromBodyAsync_ValidJson_ReturnsDto()
        {
            // Arrange
            var json = JsonSerializer.Serialize(new CreateGardenRequestDTO
            {
                UserId = 1,
                Name = "Garden",
                Location = "Location",
                Size = 100,
                ImagePath = "/images/garden.jpg"
            });

            var mockRequest = new Mock<HttpRequest>();
            mockRequest.Setup(r => r.Body).Returns(new MemoryStream(Encoding.UTF8.GetBytes(json)));

            // Act
            var result = await _service.GetDtoFromBodyAsync(mockRequest.Object);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.UserId);
            Assert.Equal("Garden", result.Name);
        }

        [Fact]
        public async Task GetDtoFromBodyAsync_InvalidJson_ReturnsNull()
        {
            // Arrange
            var mockRequest = new Mock<HttpRequest>();
            mockRequest.Setup(r => r.Body).Returns(new MemoryStream(Encoding.UTF8.GetBytes("Invalid Json")));

            // Act
            var result = await _service.GetDtoFromBodyAsync(mockRequest.Object);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task CreateGarden_ValidRequest_SavesToDatabase()
        {
            // Arrange
            var requestDTO = new CreateGardenRequestDTO
            {
                UserId = 1,
                Name = "New Garden",
                Location = "Test Location",
                Size = 100,
                ImagePath = "/images/garden.jpg"
            };

            var garden = new Models.Garden
            {
                GardenId = 1,//これを発行するのはDBなので、単体テストではこちらを指定する必要がある
                Name = requestDTO.Name,
                Location = requestDTO.Location,
                Size = requestDTO.Size,
                ImagePath = requestDTO.ImagePath,
                UserId = requestDTO.UserId
            };

            _mockContext.Setup(c => c.Gardens.Add(It.IsAny<Models.Garden>())).Callback<Models.Garden>(g =>
            {
                g.GardenId = 1; // GardenIdを手動で設定
                garden = g;
            });
            _mockContext.Setup(c => c.SaveChangesAsync(default)).ReturnsAsync(1);

            // Act
            var result = await _service.CreateGarden(requestDTO);

            // Assert
            Assert.Equal("New Garden", result.Name);
            Assert.Equal(1, result.GardenId);
            _mockContext.Verify(c => c.Gardens.Add(It.IsAny<Models.Garden>()), Times.Once);
            _mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
        }

    }
}
