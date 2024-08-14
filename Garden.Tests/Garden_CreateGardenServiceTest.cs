using Garden.Create;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Text;
using System.Text.Json;

namespace Garden.Tests
{
    public class Garden_CreateGardenServiceTest
    {
        [Fact]
        public async Task GetDtoFromBodyAsync_ValidJson_ReturnsDto()
        {
            // Arrange
            var dto = new
            {
                name = "Garden",
                size = 25.0,
                location = "Backyard",
                memo = "Test memo"
            };

            var json = JsonSerializer.Serialize(dto);
            var request = new Mock<HttpRequest>();
            request.Setup(r => r.Body).Returns(new MemoryStream(Encoding.UTF8.GetBytes(json)));

            var service = new CreateGardenService(); // ここでテストするメソッドが定義されているクラスをインスタンス化

            // Act
            var result = await service.GetDtoFromBodyAsync(request.Object);

            // Assert
            Assert.NotNull(result);
            var resultDto = Assert.IsType<CreateRequestDTO>(result);
            Assert.Equal(dto.name, resultDto.Name);
            Assert.Equal(dto.size, resultDto.Size);
            Assert.Equal(dto.location, resultDto.Location);
            Assert.Equal(dto.memo, resultDto.Memo);
        }

        [Fact]
        public async Task GetDtoFromBodyAsync_InvalidJson_ReturnsNull()
        {
            // Arrange
            var invalidJson = "{ invalid json }";
            var request = new Mock<HttpRequest>();
            request.Setup(r => r.Body).Returns(new MemoryStream(Encoding.UTF8.GetBytes(invalidJson)));

            var service = new CreateGardenService(); // ここでテストするメソッドが定義されているクラスをインスタンス化

            // Act
            var result = await service.GetDtoFromBodyAsync(request.Object);

            // Assert
            Assert.Null(result);
        }

        /*       [Fact]
               public async Task GetDtoFromBodyAsync_NullBody_ReturnsNull()
               {
                   // Arrange
                   string? invalidJson = null;
                   var request = new Mock<HttpRequest>();
                   request.Setup(r => r.Body).Returns(new MemoryStream(Encoding.UTF8.GetBytes(invalidJson)));

                   var service = new CreateGardenService();

                   // Act
                   var result = await service.GetDtoFromBodyAsync(request.Object);

                   // Assert
                   Assert.Null(result);
               }*/
    }
}
