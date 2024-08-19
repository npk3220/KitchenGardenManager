using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Garden.Create
{
    public class CreateGarden
    {
        private readonly ICreateGardenService _service;
        private readonly ILogger<CreateGarden> _logger;

        public CreateGarden(ILogger<CreateGarden> logger, ICreateGardenService service)
        {
            _logger = logger;
            _service = service;
        }

        // Todo：Createして、Blobに画像を入れるものを作成
        // Todo：DBからのエラーをサンプリングする
        // TODO: FOREACHについてチャレンジする
        [Function("CreateGarden")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "garden")] HttpRequest request)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var requestDTO = await _service.GetDtoFromBodyAsync(request);

            if (requestDTO is null)
            {
                return new BadRequestObjectResult("batRequest");
            }

            // リクエストの妥当性を判定
            if (!_service.IsValid(requestDTO))
            {
                return new BadRequestObjectResult("batRequest");
            };

            // DBに保存
            var garden = await _service.CreateGarden(requestDTO);

            return new OkObjectResult(_service.GetResponseDTO(garden));
        }
    }
}
