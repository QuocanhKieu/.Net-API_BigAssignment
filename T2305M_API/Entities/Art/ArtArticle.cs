using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace T2305M_API.Entities
{
    public class ArtArticle
    {
        [Key]
        public int ArtArticleId { get; set; }  // Primary Key

        [Required]
        [StringLength(100, ErrorMessage = "Title length can't be more than 100 characters.")]
        public string Title { get; set; }  // Title of the article

        [Required]
        public string Content { get; set; }  // Content of the article

        [Required]
        public string ThumbnailImage { get; set; }  // Thumbnail for the Article

        public bool IsActive { get; set; } = true;  // Default to active

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  // Auto-set on creation

        [ForeignKey("Art")]
        public int ArtId { get; set; }  // Foreign Key to Art

        public Art Art { get; set; }  // Navigation property

        public int? CreatorId { get; set; }  // Foreign Key to Creator

        public Creator? Creator { get; set; }  // Navigation property

        public ICollection<ArtArticleImage>? ArtArticleImages { get; set; }  // Navigation property to ArtArticleImages
    }
}
