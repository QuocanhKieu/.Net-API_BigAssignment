namespace T2305M_API.Entities
{
    public class Admin
    {
        public int AdminId { get; set; } // Primary Key
        public string Thumbnail { get; set; } // Thumbnail image
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } // e.g., Content Reviewer, Moderator, SuperAdmin
    }

}
