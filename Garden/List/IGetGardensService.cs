// Ignore Spelling: Dto

using Microsoft.AspNetCore.Http;

namespace Garden.List
{
    public interface IGetGardensService : IService
    {

        public GetGardensRequestDTO? GetDtoFromQuery(HttpRequest request);

        public Task<List<GetGardensResponseDTO>> GetGardenListAsync(GetGardensRequestDTO requestDto);
    }
}
