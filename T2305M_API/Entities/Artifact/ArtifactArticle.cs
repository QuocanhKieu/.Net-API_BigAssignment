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
        public string Title { get; set; }  // Title of the article
        public string Content { get; set; }  // Content of the article
        public string ThumbnailImage { get; set; }  
        public string Description { get; set; }  
        public bool IsActive { get; set; } = true; 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  
        [ForeignKey("Artifact")]
        public int ArtifactId { get; set; }  // Foreign Key to Artifact
        public Artifact Artifact { get; set; }  // Navigation property
        [ForeignKey("Creator")]
        public int? CreatorId { get; set; }  // Foreign Key to Creator
        public Creator? Creator { get; set; }  // Navigation property
        public ICollection<ArtifactArticleImage>? ArtifactArticleImages { get; set; }  
    }
}
