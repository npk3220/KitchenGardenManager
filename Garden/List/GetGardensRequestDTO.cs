using System.Text.Json.Serialization;


namespace Garden.List
{
    public class GetGardensRequestDTO : DTO
    {
        [JsonPropertyName("userName")]
        public string? UserName { get; set; }

        [JsonPropertyName("gardenName")]
        public string? GardenName { get; set; }

        [JsonPropertyName("isManagementEnded")]
        public bool? IsManagementEnded { get; set; }

        /*        [JsonPropertyName("registrationDate")]
                public DateTime? RegistrationDate { get; set; }*/
    }
}
