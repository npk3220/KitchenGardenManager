namespace Garden.List
{
    public class GetGardensResponseDTO : DTO
    {
        public int GardenId { get; set; }
        public required string GardenName { get; set; }
        public required string Location { get; set; }
        public required double Size { get; set; }
        public string? ImagePath { get; set; }
        public bool IsManagementEnded { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UserId { get; set; }
        public required string UserName { get; set; }
    }
}
