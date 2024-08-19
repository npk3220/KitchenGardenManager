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

        // Todo�FCreate���āABlob�ɉ摜��������̂��쐬
        // Todo�FDB����̃G���[���T���v�����O����
        // TODO: FOREACH�ɂ��ă`�������W����
        [Function("CreateGarden")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "garden")] HttpRequest request)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var requestDTO = await _service.GetDtoFromBodyAsync(request);

            if (requestDTO is null)
            {
                return new BadRequestObjectResult("batRequest");
            }

            // ���N�G�X�g�̑Ó����𔻒�
            if (!_service.IsValid(requestDTO))
            {
                return new BadRequestObjectResult("batRequest");
            };

            // DB�ɕۑ�
            var garden = await _service.CreateGarden(requestDTO);

            return new OkObjectResult(_service.GetResponseDTO(garden));
        }
    }
}
