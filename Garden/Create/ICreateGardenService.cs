﻿// Ignore Spelling: Dto

using Microsoft.AspNetCore.Http;

namespace Garden.Create
{
    public interface ICreateGardenService : IService
    {

        public Task<CreateGardenRequestDTO>? GetDtoFromBodyAsync(HttpRequest request);

        public bool IsValid(DTO createRequestDto);

        public Task<Models.Garden> CreateGarden(CreateGardenRequestDTO requestDTO);

        public CreateGardenResponseDTO GetResponseDTO(Models.Garden garden);
    }
}
