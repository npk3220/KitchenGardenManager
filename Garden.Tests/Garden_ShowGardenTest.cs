using Garden.Show;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Moq;

namespace Garden.Tests;
public class Garden_ShowGardenTest
{
    private readonly Mock<ILogger<ShowGarden>> _loggerMock;
    private readonly ShowGarden _showGarden;

    public Garden_ShowGardenTest()
    {
        _loggerMock = new Mock<ILogger<ShowGarden>>();
        _showGarden = new ShowGarden(_loggerMock.Object);
    }

    [Fact]
    public async Task Run_ShouldReturnBadRequest_WhenNoNamesProvided()
    {
        // Arrange
        var context = new DefaultHttpContext();
        var request = context.Request;
        request.Query = new QueryCollection();  // Empty query string

        // Act
        var result = await _showGarden.Run(request, 1);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("Please pass at least one Name on the query string", badRequestResult.Value);
    }

    [Fact]
    public async Task Run_ShouldReturnOkResult_WhenNamesProvided()
    {
        // Arrange
        var context = new DefaultHttpContext();
        var request = context.Request;

        var query = new QueryCollection(new Dictionary<string, StringValues>
        {
            // .NetÇ≈ÇÕgarden/1?Name=test&Name=sampleÇîzóÒÇ∆ÇµÇƒóùâÇ∑ÇÈÅB
            { "Name", new StringValues(new[] { "test", "sample" }) }
        });
        request.Query = query;

        // Act
        var result = await _showGarden.Run(request, 1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal("Garden Id is 1 Name is, test, sample", okResult.Value);
    }
}
