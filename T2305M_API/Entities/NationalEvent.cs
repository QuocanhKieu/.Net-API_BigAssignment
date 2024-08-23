using System.ComponentModel.DataAnnotations;

namespace T2305M_API.Entities
{
    public class NationalEvent
    {
        [Key]
        public int NationalEventID { get; set; } // Primary Key

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Auto-set on creation

        [Required]
        [StringLength(100, ErrorMessage = "Title length can't be more than 100 characters.")]
        public string Title { get; set; }

        [Required]
        public string ThumbnailImage { get; set; }  // Thumbnail for the NationalEvent

        [Required]
        public string Content { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Description length can't be more than 200 characters.")]
        public string Description { get; set; }

        public bool IsActive { get; set; } = true; // Default to active

        // Nullable Properties
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public ICollection<EntityImage>? NationalEventImages { get; set; }  // List of images related to the NationalEvent

        public ICollection<Article>? NationalEventArticles { get; set; } // Related articles

        public int? CreatorId { get; set; }  // Foreign Key to Creator

        public Creator? Creator { get; set; }  // Navigation property
    }
}
