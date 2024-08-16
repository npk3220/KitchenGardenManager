namespace Models
{
    public class GardenPlantRelation
    {
        public int GardenPlantRelationId { get; set; }
        public int GardenId { get; set; }
        public int PlantId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Garden Garden { get; set; }
        public Plant Plant { get; set; }
    }
}
