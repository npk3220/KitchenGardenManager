using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class PlantMaster
    {
        [Key]
        public int PlantMasterId { get; set; }
        public required string PlantName { get; set; }
        public required string ScientificName { get; set; }
        public required string PlantFamily { get; set; }
        public required string Description { get; set; }
        public required string OptimalConditions { get; set; }
        public string? ImagePath { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
