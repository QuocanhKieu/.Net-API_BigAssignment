using System.ComponentModel.DataAnnotations;

namespace T2305M_API.Entities
{
    public class Creator
    {
        [Key]
        public int CreatorId { get; set; }  // Primary Key
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Nationality { get; set; }
        public string Avatar { get; set; }
        public string Role { get; set; } = "user"; //user/ moderator / admin
        public bool IsActive { get; set; } = true; // Default to active
                                                   // Navigation Properties for Reverse Relationships
        public ICollection<History> Histories { get; set; }
        public ICollection<Culture> Cultures { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
