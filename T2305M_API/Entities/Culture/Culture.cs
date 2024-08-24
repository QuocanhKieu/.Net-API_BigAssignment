using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2305M_API.Entities
{
    public class Culture
    {
        [Key]
        public int CultureId { get; set; }  // Primary Key

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Auto-set on creation

        [Required]
        [StringLength(100, ErrorMessage = "Title length can't be more than 100 characters.")]
        public string Title { get; set; }

        [Required]
        public string ThumbnailImage { get; set; }  // Thumbnail for the Culture object

        [Required]
        public string Content { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Description length can't be more than 200 characters.")]
        public string Description { get; set; }

        public bool IsActive { get; set; } = true; // Default to active

        // Nullable Properties
        [StringLength(50, ErrorMessage = "Continent length can't be more than 50 characters.")]
        public string? Continent { get; set; }  // E.g., "Africa", "Asia", "Europe", etc.

        [StringLength(100, ErrorMessage = "Country length can't be more than 100 characters.")]
        public string? Country { get; set; }  // E.g., "USA", "China", etc.

        // Collections
        public ICollection<CultureImage>? CultureImages { get; set; }  // List of images related to the Culture object

        public ICollection<CultureArticle>? CultureArticles { get; set; }  // Related articles

        // Foreign Key to Creator
        public int? CreatorId { get; set; }

        public Creator? Creator { get; set; }  // Navigation property
    }
}
