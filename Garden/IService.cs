
using Microsoft.AspNetCore.Http;

namespace Garden
{
    public interface IService
    {
        public Task<DTO>? GetDtoFromBodyAsync(HttpRequest request);
    }
}
