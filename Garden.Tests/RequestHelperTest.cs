// Ignore Spelling: Dto

using Moq;
using System.ComponentModel.DataAnnotations;

namespace Garden.Tests
{
    public class TestDTO : DTO
    {
        [Required]
        [MinLength(1)]
        public string Name { get; set; }

        [Range(0, 100)]
        public int Age { get; set; }
    }

    public class RequestHelperTest
    {

        [Fact]
        public void IsValid_ShouldReturnTrue_WhenDtoIsValid()
        {
            // Arrange
            var dto = new TestDTO
            {
                // DTO のプロパティを設定
                Name = "ValidName",
                Age = 30
            };

            // Act
            var result = RequestHelper.IsValid(dto);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsValid_ShouldReturnFalse_WhenDtoIsInvalid()
        {
            // Arrange
            var dto = new TestDTO
            {
                // 無効な DTO のプロパティを設定
                Name = "",
                Age = -1
            };

            // Act
            var result = RequestHelper.IsValid(dto);

            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData("true", true)]
        [InlineData("false", false)]
        [InlineData("invalid", null)]
        public void StringToBool_ShouldReturnExpectedResult(string input, bool? expectedResult)
        {
            // Act
            var result = RequestHelper.StringToBool(input);

            // Assert
            Assert.Equal(expectedResult, result);
        }

    }
}
