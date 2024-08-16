namespace Models
{
    public class Garden
    {
        public int GardenId { get; set; }
        public int UserId { get; set; }
        public required string Name { get; set; }
        public required string Location { get; set; }
        public required double Size { get; set; }
        public string? ImagePath { get; set; }
        public bool IsManagementEnded { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public User User { get; set; }
        public ICollection<GardenHistory> GardenHistories { get; set; }
        public ICollection<GardenPlantRelation> GardenPlantRelations { get; set; }
    }
}
