using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Garden.Update
{
    public class ShowGardenService : IService
    {
        public async Task<DTO>? GetDtoFromBodyAsync(HttpRequest request)
        {
            DTO? Result = null;

            try
            {
                using (var reader = new StreamReader(request.Body))
                {
                    var body = await reader.ReadToEndAsync();
                    Result = JsonSerializer.Deserialize<ShowRequestDTO>(body);
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
