using System.ComponentModel.DataAnnotations;

namespace T2305M_API.Entities
{
    public class Artifact
    {
        [Key]
        public int ArtifactId { get; set; }  // Primary Key

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Auto-set on creation

        [Required]
        [StringLength(100, ErrorMessage = "Title length can't be more than 100 characters.")]
        public string Title { get; set; }

        [Required]
        public string ThumbnailImage { get; set; }  // Thumbnail for the Artifact

        [Required]
        public string Content { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Description length can't be more than 200 characters.")]
        public string Description { get; set; }

        public bool IsActive { get; set; } = true; // Default to active
        // Nullable Properties
        [StringLength(100)]  // Set a maximum length for the discovered date string
        public string? DiscoveredDate { get; set; }

        [StringLength(50)]  // Set a maximum length for the continent name
        public string? Continent { get; set; }  // E.g., "Africa", "Asia", "Europe", etc.

        [StringLength(100)]  // Set a maximum length for the country name
        public string? Country { get; set; }  // E.g., "USA", "China", etc.

        public ICollection<EntityImage>? ArtifactImages { get; set; }  // List of images related to the Artifact

        public ICollection<Article>? ArtifactArticles { get; set; }  // Related articles

        public int? CreatorId { get; set; }  // Foreign Key to Author

        public Creator? Creator { get; set; }  // Navigation property
    }
}
