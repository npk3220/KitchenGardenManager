using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Garden.Show
{
    public class ShowGarden
    {
        private readonly IService _service;
        private readonly ILogger<ShowGarden> _logger;

        public ShowGarden(ILogger<ShowGarden> logger, IService service)
        {
            _logger = logger;
            _service = service;
        }

        [Function("CreateGarden")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "garden")] HttpRequest request)
        {
            var requestDTO = await _service.GetDtoFromBodyAsync(request);

            if (requestDTO is null)
            {
                return new BadRequestObjectResult("batRequest");
            }

            // ���N�G�X�g�̑Ó����𔻒�

            // DB�ɕۑ�

            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Garden Functions!");
        }
    }
}
