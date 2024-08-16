using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class GardenHistory
    {
        [Key]
        public int GardenHistoryId { get; set; }
        public int GardenId { get; set; }
        public string ActionType { get; set; } // 施肥や測定の種類
        public string Details { get; set; } // 詳細
        public DateTime ActionDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Garden Garden { get; set; }
    }
}
