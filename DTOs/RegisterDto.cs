namespace Team1_SmartBank.API.DTOs
{
    public class RegisterDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        // ✅ ROLE INCLUDED
        public string Role { get; set; }  // Customer / Manager / Admin
    }
}