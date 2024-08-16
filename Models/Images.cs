namespace Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public int UserId { get; set; }
        public int? GardenId { get; set; }
        public int? PlantId { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public DateTime UploadedAt { get; set; }

        public User User { get; set; }
        public Garden Garden { get; set; }
        public PlantMaster Plant { get; set; }
    }
}
