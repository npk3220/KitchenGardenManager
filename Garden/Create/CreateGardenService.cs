// Ignore Spelling: Dto

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Garden.Create
{
    public class CreateGardenService : IService
    {
        ILogger<CreateGardenService> _logger;
        public CreateGardenService(ILogger<CreateGardenService> logger)
        {
            _logger = logger;
        }

        public async Task<DTO>? GetDtoFromBodyAsync(HttpRequest request)
        {
            DTO? Result = null;

            try
            {
                using (var reader = new StreamReader(request.Body))
                {
                    var body = await reader.ReadToEndAsync();
                    Result = JsonSerializer.Deserialize<CreateRequestDTO>(body);
                }
            }
            catch (JsonException e)
            {
                Console.Write(e.Message);
            }
            return Result;
        }

        public bool IsValid(DTO createRequestDto)
        {
            return RequestHelper.IsValid(createRequestDto);
        }


    }
}
