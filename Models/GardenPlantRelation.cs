using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class GardenPlantRelation
    {
        [Key]
        public int GardenPlantRelationId { get; set; }
        public int GardenId { get; set; }
        public int PlantId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Garden Garden { get; set; }
        public Plant Plant { get; set; }
    }
}
