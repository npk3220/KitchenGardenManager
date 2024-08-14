using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace Garden.Update
{
    public class ShowRequestDTO : DTO
    {
        [MaxLength(10)]
        [MinLength(3)]
        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("size")]
        public required double Size { get; set; }

        [JsonPropertyName("location")]
        public required string Location { get; set; }

        [JsonPropertyName("memo")]
        public string? Memo { get; set; }
    }
}
