namespace Models
{
    public class PlantHistory
    {
        public int PlantHistoryId { get; set; }
        public int PlantId { get; set; }
        public int PlantStatusId { get; set; }
        public string? Notes { get; set; }
        public string? ImagePath { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Plant Plant { get; set; }
        public PlantStatusMaster PlantStatus { get; set; }
    }
}
