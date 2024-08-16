namespace Models
{
    public class PlantStatusMaster
    {
        public int PlantStatusMasterId { get; set; }
        public string StatusName { get; set; } // 状態名（例: 植え付け、発芽、収穫、開花、枯死、施肥、病害虫、その他）
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
