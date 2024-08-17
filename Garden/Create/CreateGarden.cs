using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Garden.Create
{
    public class CreateGarden
    {
        private readonly IService _service;
        private readonly ILogger<CreateGarden> _logger;

        public CreateGarden(ILogger<CreateGarden> logger, IService service)
        {
            _logger = logger;
            _service = service;
        }

        [Function("CreateGarden")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "garden")] HttpRequest request)
        {
            /*            var requestDTO = await _service.GetDtoFromBodyAsync(request);

                        if (requestDTO is null)
                        {
                            return new BadRequestObjectResult("batRequest");
                        }*/

            // リクエストの妥当性を判定

            // DBに保存

            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Garden Functions!");
        }
    }
}
