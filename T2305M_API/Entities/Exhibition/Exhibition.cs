using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2305M_API.Entities
{
    public class Exhibition
    {
        [Key]
        public int ExhibitionId { get; set; }  // Primary Key
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Auto-set on creation
        public string Title { get; set; }
        public string ThumbnailImage { get; set; }  // Thumbnail for the Exhibition
        public string Content { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true; 
        public string? Location { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Organizer { get; set; }
        public string? Continent { get; set; } 
        public string? Country { get; set; }  // E.g., "USA", "China", etc.

        // Collections
        public ICollection<ExhibitionImage>? ExhibitionImages { get; set; }  // List of images related to the Exhibition

        public ICollection<ExhibitionArticle>? ExhibitionArticles { get; set; }  // Related articles

        [ForeignKey("Creator")]
        public int? CreatorId { get; set; }  // Foreign Key to Creator
        public Creator? Creator { get; set; }  // Navigation property
    }
}
