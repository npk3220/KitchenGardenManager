using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Plant
    {
        [Key]
        public int PlantId { get; set; }
        public required string Name { get; set; }
        public int? PlantMasterId { get; set; } // 植物の種類、植物マスターに存在しない場合もある
        public int Quantity { get; set; } // 植えた量
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<GardenPlantRelation> GardenPlantRelations { get; set; }
        public ICollection<PlantHistory> PlantHistories { get; set; }
    }
}
