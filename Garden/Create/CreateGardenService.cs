// Ignore Spelling: Dto

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Models;
using System.Text.Json;

namespace Garden.Create
{
    public class CreateGardenService : ICreateGardenService
    {
        ILogger<CreateGardenService> _logger;
        private readonly HomeGardenContext _dbContext;
        public CreateGardenService(ILogger<CreateGardenService> logger, HomeGardenContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<CreateGardenRequestDTO>? GetDtoFromBodyAsync(HttpRequest request)
        {
            CreateGardenRequestDTO? Result = null;

            try
            {
                using (var reader = new StreamReader(request.Body))
                {
                    var body = await reader.ReadToEndAsync();
                    Result = JsonSerializer.Deserialize<CreateGardenRequestDTO>(body);
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
        // Todo：fieldについてもテストできるかチャレンジする

        public async Task<Models.Garden> CreateGarden(CreateGardenRequestDTO requestDTO)
        {
            var garden = new Models.Garden
            {
                Name = requestDTO.Name,
                Location = requestDTO.Location,
                Size = requestDTO.Size,
                ImagePath = requestDTO.ImagePath,
                IsManagementEnded = false,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                UserId = requestDTO.UserId
            };
            _dbContext.Gardens.Add(garden);
            await _dbContext.SaveChangesAsync();
            return garden;
        }

        public CreateGardenResponseDTO GetResponseDTO(Models.Garden garden)
        {
            return new CreateGardenResponseDTO
            {
                GardenId = garden.GardenId,
                Message = "Garden created successfully."
            };
        }
    }
}
