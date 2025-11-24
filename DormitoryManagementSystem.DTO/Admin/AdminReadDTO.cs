namespace DormitoryManagementSystem.DTO.Admins
{
    public class AdminReadDTO
    {
        public string AdminID { get; set; } = string.Empty;
        public string UserID { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string IDcard { get; set; } = string.Empty;
        public string? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}