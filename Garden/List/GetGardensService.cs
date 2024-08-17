// Ignore Spelling: Dto

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;

namespace Garden.List
{
    public class GetGardensService : IGetGardensService
    {
        private readonly HomeGardenContext _dbContext;
        private readonly ILogger<GetGardensService> _logger;

        public GetGardensService(ILogger<GetGardensService> logger, HomeGardenContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public GetGardensRequestDTO? GetDtoFromQuery(HttpRequest request)
        {
            GetGardensRequestDTO? result = null;

            try
            {
                var query = request.Query;

                var isManagementEnded = query.ContainsKey("isManagementEnded") ? query["isManagementEnded"].ToString() : null;
                // var registrationDateString = query.ContainsKey("registrationDate") ? query["registrationDate"].ToString() : null;

                result = new GetGardensRequestDTO
                {
                    UserName = query.ContainsKey("userName") ? query["userName"].ToString() : null,
                    GardenName = query.ContainsKey("gardenName") ? query["gardenName"].ToString() : null,
                    IsManagementEnded = (isManagementEnded is not null) ?
                        RequestHelper.StringToBool(isManagementEnded) : null,
                    /*RegistrationDate = !string.IsNullOrEmpty(registrationDateString)
                           ? DateTime.Parse(registrationDateString)
                           : null*/
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public async Task<List<GetGardensResponseDTO>> GetGardenListAsync(GetGardensRequestDTO requestDto)
        {
            var query = _dbContext.Gardens.AsQueryable();

            // ユーザー名でフィルタリング（関連する User テーブルを含める）
            if (!string.IsNullOrEmpty(requestDto.UserName))
            {
                query = query.Where(g => g.User.UserName.Contains(requestDto.UserName));
            }

            // ガーデン名でフィルタリング
            if (!string.IsNullOrEmpty(requestDto.GardenName))
            {
                query = query.Where(g => g.Name.Contains(requestDto.GardenName));
            }

            // 管理終了ステータスでフィルタリング
            if (requestDto.IsManagementEnded.HasValue)
            {
                query = query.Where(g => g.IsManagementEnded == requestDto.IsManagementEnded.Value);
            }

            // Todo: 今植えられている植物一覧もほしい
            return await query.Select(g => new GetGardensResponseDTO
            {
                GardenId = g.GardenId,
                GardenName = g.Name,
                Location = g.Location,
                Size = g.Size,
                ImagePath = g.ImagePath,
                IsManagementEnded = g.IsManagementEnded,
                CreatedAt = g.CreatedAt,
                UpdatedAt = g.UpdatedAt,
                UserId = g.UserId,
                UserName = g.User.UserName,
            }).ToListAsync();
        }
    }
}
