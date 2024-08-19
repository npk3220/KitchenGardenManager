using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace Garden.Create
{
    public class CreateGardenResponseDTO : DTO
    {
        public int GardenId { get; set; }
        public string Message { get; set; }
    }
}
