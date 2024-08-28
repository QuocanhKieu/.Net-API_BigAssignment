using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace T2305M_API.Entities
{
    public class Artifact
    {
        [Key]
        public int ArtifactId { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 
        public string Title { get; set; }
        public string ThumbnailImage { get; set; }  // Thumbnail for the Artifact
        public string Content { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true; // Default to active
        public string? DiscoveredDate { get; set; }
        public string? Continent { get; set; }  // E.g., "Africa", "Asia", "Europe", etc.
        public string? Country { get; set; }  // E.g., "USA", "China", etc.

        // Navigation Properties
        public ICollection<ArtifactImage>? ArtifactImages { get; set; }  // List of images related to the Artifact

        public ICollection<ArtifactArticle>? ArtifactArticles { get; set; }  // Related articles

        public int? CreatorId { get; set; }  // Foreign Key to Creator

        public Creator? Creator { get; set; }  // Navigation property
    }
}
