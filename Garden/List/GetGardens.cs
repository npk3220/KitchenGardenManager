using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Garden.List
{
    public class GetGardens
    {
        private readonly IGetGardensService _service;
        private readonly ILogger<GetGardens> _logger;

        public GetGardens(ILogger<GetGardens> logger, IGetGardensService service)
        {
            _logger = logger;
            _service = service;
        }

        [Function("GetGardens")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "garden")] HttpRequest request)
        {
            // リクエストの妥当性を判定
            var requestDTO = _service.GetDtoFromQuery(request);

            if (requestDTO is null)
            {
                return new BadRequestObjectResult("batRequest");
            }

            // DBから取得
            var gardenList = await _service.GetGardenListAsync(requestDTO);

            // レスポンスを返す
            return new OkObjectResult(gardenList);
        }
    }
}
