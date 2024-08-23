using System.ComponentModel.DataAnnotations;

namespace T2305M_API.Entities
{
    public class Exhibition
    {
        [Key]
        public int ExhibitionId { get; set; } // Primary Key

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Auto-set on creation

        [Required]
        [StringLength(100, ErrorMessage = "Title length can't be more than 100 characters.")]
        public string Title { get; set; }

        [Required]
        public string ThumbnailImage { get; set; }  // Thumbnail for the Exhibition

        [Required]
        public string Content { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Description length can't be more than 200 characters.")]
        public string Description { get; set; }

        public bool IsActive { get; set; } = true; // Default to active

        // Nullable Properties

        [StringLength(200, ErrorMessage = "Location cannot exceed 200 characters.")]
        public string? Location { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [StringLength(100, ErrorMessage = "Organizer cannot exceed 100 characters.")]
        public string? Organizer { get; set; }

        [StringLength(50, ErrorMessage = "Continent cannot exceed 50 characters.")]
        public string? Continent { get; set; }  // E.g., "Africa", "Asia", "Europe", etc.

        [StringLength(100, ErrorMessage = "Country cannot exceed 100 characters.")]
        public string? Country { get; set; }  // E.g., "USA", "China", etc.

        public ICollection<EntityImage>? ExhibitionImages { get; set; }  // List of images related to the Exhibition

        public ICollection<Article>? ExhibitionArticles { get; set; }  // Related articles

        public int? CreatorId { get; set; }  // Foreign Key to Creator

        public Creator? Creator { get; set; }  // Navigation property
    }
}
