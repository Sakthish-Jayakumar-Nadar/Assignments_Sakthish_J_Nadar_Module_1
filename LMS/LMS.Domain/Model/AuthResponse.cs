namespace LMS.Domain.Model
{
    public class AuthResponse
    {
        public string Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
