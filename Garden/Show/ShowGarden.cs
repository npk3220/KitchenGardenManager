using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Garden.Show
{
    public class ShowGarden
    {
        private readonly ILogger<ShowGarden> _logger;

        public ShowGarden(ILogger<ShowGarden> logger)
        {
            _logger = logger;
        }

        [Function("ShowGarden")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "garden/{id}")] HttpRequest request, int id)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            var names = request.Query["Name"].ToArray();

            if (names == null || names.Length == 0)
            {
                return new BadRequestObjectResult("Please pass at least one Name on the query string");
            }

            var responseMessage = $"Garden Id is {id} Name is, {string.Join(", ", names)}";
            return new OkObjectResult(responseMessage);
        }
    }
}
