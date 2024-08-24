using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2305M_API.Entities
{
    public class ArtifactArticle
    {
        [Key]
        public int ArtifactArticleId { get; set; }  // Primary Key

        [Required]
        [StringLength(100, ErrorMessage = "Title length can't be more than 100 characters.")]
        public string Title { get; set; }  // Title of the article

        [Required]
        public string Content { get; set; }  // Content of the article

        [Required]
        [StringLength(255, ErrorMessage = "ThumbnailImage length can't be more than 255 characters.")]
        public string ThumbnailImage { get; set; }  // Thumbnail for the Article

        [Required]
        [StringLength(200, ErrorMessage = "Description length can't be more than 200 characters.")]
        public string Description { get; set; }  // Short description of the article

        public bool IsActive { get; set; } = true;  // Indicates if the article is active

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  // Auto-set on creation

        [ForeignKey("Artifact")]
        public int ArtifactId { get; set; }  // Foreign Key to Artifact

        public Artifact Artifact { get; set; }  // Navigation property

        public int? CreatorId { get; set; }  // Foreign Key to Creator

        public Creator? Creator { get; set; }  // Navigation property

        public ICollection<ArtifactArticleImage>? ArtifactArticleImages { get; set; }  // Navigation property to ArtifactArticleImages
    }
}
