using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Garden.List
{
    public class ListGardenService : IService
    {
        public async Task<DTO>? GetDtoFromBodyAsync(HttpRequest request)
        {
            DTO? Result = null;

            try
            {
                using (var reader = new StreamReader(request.Body))
                {
                    var body = await reader.ReadToEndAsync();
                    Result = JsonSerializer.Deserialize<ListRequestDTO>(body);
                }
            }
            catch (JsonException e)
            {
                Console.Write(e.Message);
            }
            return Result;
        }
    }
}
