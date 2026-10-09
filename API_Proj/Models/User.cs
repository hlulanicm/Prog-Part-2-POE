using Microsoft.AspNetCore.Authentication.Cookies;



namespace API_proj.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string UserSurname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = "Participant";
        public string? PhoneNumber { get; set; }
    }
}