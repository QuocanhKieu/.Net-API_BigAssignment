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
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Auto-set on creation
        public string Title { get; set; }
        public string ThumbnailImage { get; set; }  // Thumbnail for the Culture object
        public string Content { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true; // Default to active
        public string? Continent { get; set; }  // E.g., "Africa", "Asia", "Europe", etc.
        public string? Country { get; set; }  // E.g., "USA", "China", etc.

        // Collections
        public ICollection<CultureImage>? CultureImages { get; set; }  // List of images related to the Culture object
        public ICollection<CultureArticle>? CultureArticles { get; set; }  // Related articles
        public int? CreatorId { get; set; }
        public Creator? Creator { get; set; }  // Navigation property
    }
}
