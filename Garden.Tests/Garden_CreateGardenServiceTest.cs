// Ignore Spelling: Dto

using Garden.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using System.Text;
using System.Text.Json;

namespace Garden.Tests
{
    public class Garden_CreateGardenServiceTest
    {
        static ILogger<CreateGardenService> _logger = Mock.Of<ILogger<CreateGardenService>>();
        CreateGardenService _service = new(_logger); // ここでテストするメソッドが定義されているクラスをインスタンス化

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

            // Act
            var result = await _service.GetDtoFromBodyAsync(request.Object);

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

            // Act
            var result = await _service.GetDtoFromBodyAsync(request.Object);

            // Assert
            Assert.Null(result);
        }

        /*        [Fact]
                public async Task GetDtoFromBodyAsync_NullBody_ReturnsNull()
                {
                    // Arrange
                    var request = new Mock<HttpRequest>();
                    request.Setup(r => r.Body).Returns((Stream)null);

                    var service = new CreateGardenService();

                    // Act
                    var result = await service.GetDtoFromBodyAsync(request.Object);

                    // Assert
                    Assert.Null(result);
                }*/


        [Fact]
        public void IsValid_ValidDTO_ReturnsTrue()
        {
            // Arrange
            var dto = new CreateRequestDTO
            {
                Name = "Garden",
                Size = 25.0,
                Location = "Backyard",
                Memo = "Test memo"
            };

            // Act
            var isValid = _service.IsValid(dto);

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void IsValid_InvalidName_ReturnsFalse()
        {
            // Arrange
            var dto = new CreateRequestDTO
            {
                Name = "TooLongName123",
                Size = 25.0,
                Location = "Backyard",
                Memo = "Test memo"
            };

            // Act
            var isValid = _service.IsValid(dto);

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_InvalidSize_ReturnsFalse()
        {
            // Arrange
            var dto = new CreateRequestDTO
            {
                Name = "Garden",
                Size = -5.0,
                Location = "Backyard",
                Memo = "Test memo"
            };

            // Act
            var isValid = _service.IsValid(dto);

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_MultipleErrors_ReturnsFalse()
        {
            // Arrange
            var dto = new CreateRequestDTO
            {
                Name = "No",
                Size = 0.0,
                Location = "",  // Assuming location should not be empty unless otherwise stated
                Memo = "Test memo"
            };

            // Act
            var isValid = _service.IsValid(dto);

            // Assert
            Assert.False(isValid);
            /*            Assert.Contains(validationErrors, e => e.Contains("The field Name must be a string with a minimum length of 3."));
                        Assert.Contains(validationErrors, e => e.Contains("The Location field is required."));*/
        }

    }
}
