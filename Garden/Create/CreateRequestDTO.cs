using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace Garden.Create
{
    public class CreateGardenRequestDTO : DTO
    {
        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [MaxLength(10)]
        [MinLength(3)]
        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("location")]
        public required string Location { get; set; }

        [Range(0.0, double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        [JsonPropertyName("size")]
        public required double Size { get; set; }

        [JsonPropertyName("imagePath")]
        public required string ImagePath { get; set; }


        [JsonPropertyName("memo")]
        public string? Memo { get; set; }
    }
}
