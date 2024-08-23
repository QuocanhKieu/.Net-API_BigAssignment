using System.ComponentModel.DataAnnotations;

namespace T2305M_API.Entities
{
    public class Art
    {
        [Key]
        public int ArtId { get; set; } // Primary Key

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Auto-set on creation

        [Required]
        [StringLength(100, ErrorMessage = "Title length can't be more than 100 characters.")]
        public string Title { get; set; }

        [Required]
        public string ThumbnailImage { get; set; }  // Thumbnail for the Art object

        [Required]
        public string Content { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Description length can't be more than 200 characters.")]
        public string Description { get; set; }

        public bool IsActive { get; set; } = true; // Default to active

        // Nullable Properties
        [StringLength(100, ErrorMessage = "Artist name length can't be more than 100 characters.")]
        public string? Artist { get; set; }

        [StringLength(50, ErrorMessage = "Period length can't be more than 50 characters.")]
        public string? Period { get; set; }

        [StringLength(50, ErrorMessage = "Type length can't be more than 50 characters.")]
        public string? Type { get; set; } // E.g., Painting, Sculpture, etc.

        [StringLength(50, ErrorMessage = "Continent length can't be more than 50 characters.")]
        public string? Continent { get; set; }  // E.g., "Africa", "Asia", "Europe", etc.

        [StringLength(50, ErrorMessage = "Country length can't be more than 50 characters.")]
        public string? Country { get; set; }  // E.g., "Africa", "Asia", "Europe", etc.

        // Navigation Properties
        public ICollection<EntityImage>? ArtImages { get; set; }  // List of images related to the Art object
        public ICollection<Article>? ArtArticles { get; set; } // Navigation property to Art Articles

        public int? CreatorId { get; set; }  // Foreign Key to Author

        public Creator? Creator { get; set; }  // Navigation property
    }
}
