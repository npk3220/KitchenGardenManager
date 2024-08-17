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
            // ���N�G�X�g�̑Ó����𔻒�
            var requestDTO = _service.GetDtoFromQuery(request);

            if (requestDTO is null)
            {
                return new BadRequestObjectResult("batRequest");
            }

            // DB����擾
            var gardenList = await _service.GetGardenListAsync(requestDTO);

            // ���X�|���X��Ԃ�
            return new OkObjectResult(gardenList);
        }
    }
}
