namespace DormitoryManagementSystem.API.Models
{
    public class LoginRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }

    public class LoginResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? DisplayName { get; set; }
        public string? Role { get; set; }
        public string? Token { get; set; }
        public UserSummary? User { get; set; }
    }

    public class UserSummary
    {
        public string UserId { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }

    public class UserSession
    {
        public UserSession(string userId, string username, string role)
        {
            UserId = userId;
            Username = username;
            Role = role;
        }

        public string UserId { get; }
        public string Username { get; }
        public string Role { get; }
    }
}

