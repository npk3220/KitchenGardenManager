using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using Garden.List;
using Models;

namespace Garden.Tests
{
    public class Garden_GetGardensServiceTests
    {
        private readonly Mock<HomeGardenContext> _mockDbContext;
        private readonly Mock<ILogger<GetGardensService>> _mockLogger;
        private readonly GetGardensService _service;

        public Garden_GetGardensServiceTests()
        {
            _mockDbContext = new Mock<HomeGardenContext>();
            _mockLogger = new Mock<ILogger<GetGardensService>>();
            _service = new GetGardensService(_mockLogger.Object, _mockDbContext.Object);
        }

        [Fact]
        public void GetDtoFromQuery_ValidQuery_ReturnsCorrectDto()
        {
            // Arrange
            var queryString = new QueryCollection(new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>
            {
                { "userName", "TestUser" },
                { "gardenName", "TestGarden" },
                { "isManagementEnded", "true" }
            });
            var mockRequest = new Mock<HttpRequest>();
            mockRequest.Setup(r => r.Query).Returns(queryString);

            // Act
            var result = _service.GetDtoFromQuery(mockRequest.Object);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("TestUser", result.UserName);
            Assert.Equal("TestGarden", result.GardenName);
            Assert.True(result.IsManagementEnded);
        }

        [Fact]
        public void GetDtoFromQuery_InvalidQuery_ReturnsNull()
        {
            // Arrange
            var queryString = new QueryCollection(new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>
            {
                { "isManagementEnded", "not_a_bool" }
            });
            var mockRequest = new Mock<HttpRequest>();
            mockRequest.Setup(r => r.Query).Returns(queryString);

            // Act
            var result = _service.GetDtoFromQuery(mockRequest.Object);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.IsManagementEnded);
        }

        [Fact]
        public async Task GetGardenListAsync_ValidRequest_ReturnsGardens()
        {
            // InMemoryDatabaseを使用してHomeGardenContextを作成
            var options = new DbContextOptionsBuilder<HomeGardenContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new HomeGardenContext(options))
            {
                // テストデータをシード（準備）
                ModelMock.SetSeedTestData(context);

                var service = new GetGardensService(_mockLogger.Object, context);

                var requestDto = new GetGardensRequestDTO
                {
                    UserName = "TestUser",
                    GardenName = "TestGarden"
                };

                // Act
                var result = await service.GetGardenListAsync(requestDto);

                // Assert
                Assert.NotNull(result);
                Assert.Single(result);
                Assert.Equal("TestGarden", result.First().GardenName);
                Assert.Equal("TestUser", result.First().UserName);
            }
        }

    }
}
