using System.ComponentModel.DataAnnotations;

namespace T2305M_API.Entities
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }  // Primary Key

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
        public int? RelatedEntityId { get; set; }  // ID of the related entity (e.g., ArtId, BookId, etc.)

        [MaxLength(100)]  // Limit the length of RelatedEntityType to 100 characters
        public string? RelatedEntityType { get; set; }  // Type of the related entity (e.g., "Art", "Book", etc.)

        public ICollection<ArticleImage>? ArticleImages { get; set; }

        public int? CreatorId { get; set; }  // Foreign Key to Author

        public Creator? Creator { get; set; }  // Navigation property

        // Optional Navigation Properties
        public Art? Art { get; set; }
        public Book? Book { get; set; }
        public Exhibition? Exhibition { get; set; }
        public Culture? Culture { get; set; }
        public Artifact? Artifact { get; set; }
        public NationalEvent? NationalEvent { get; set; }
    }
}
