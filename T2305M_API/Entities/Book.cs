using System.ComponentModel.DataAnnotations;

namespace T2305M_API.Entities
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }  // Primary Key

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Auto-set on creation

        [Required]
        [StringLength(100, ErrorMessage = "Title length can't be more than 100 characters.")]
        public string Title { get; set; }

        [Required]
        public string ThumbnailImage { get; set; }  // Thumbnail for the Book object

        [Required]
        public string Content { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Description length can't be more than 200 characters.")]
        public string Description { get; set; }

        public bool IsActive { get; set; } = true; // Default to active

        // Nullable Properties
        [StringLength(50)]  // Simplified length constraint for the author
        public string? Author { get; set; }

        [StringLength(50)]  // Simplified length constraint for the published date
        public string? PublishedDate { get; set; }

        [StringLength(30)]  // Simplified length constraint for the type
        public string? Type { get; set; }

        [StringLength(30)]  // Simplified length constraint for the continent
        public string? Continent { get; set; }

        [StringLength(50)]  // Simplified length constraint for the country
        public string? Country { get; set; }

        [StringLength(50)]  // Simplified length constraint for the publisher
        public string? Publisher { get; set; }

        public ICollection<EntityImage>? BookImages { get; set; }  // List of images related to the Book object

        public ICollection<Article>? BookArticles { get; set; }  // Related articles

        public int? CreatorId { get; set; }  // Foreign Key to Author

        public Creator? Creator { get; set; }  // Navigation property
    }
}
