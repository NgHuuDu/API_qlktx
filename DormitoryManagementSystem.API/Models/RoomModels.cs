namespace DormitoryManagementSystem.API.Models
{
    public class RoomResponse
    {
        public string RoomId { get; set; } = string.Empty;
        public int RoomNumber { get; set; }
        public string BuildingId { get; set; } = string.Empty;
        public string Building { get; set; } = string.Empty;
        public string RoomType { get; set; } = string.Empty;
        public int CurrentOccupants { get; set; }
        public int MaxOccupants { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsFull => MaxOccupants == 0 ? false : CurrentOccupants >= MaxOccupants;
    }
}

