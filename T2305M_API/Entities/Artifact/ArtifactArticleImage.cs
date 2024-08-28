using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2305M_API.Entities
{
    public class ArtifactArticleImage
    {
        [Key]
        public int ArtifactArticleImageId { get; set; }  // Primary Key
        public string ImageUrl { get; set; }  // URL to the image
        [ForeignKey("ArtifactArticle")]
        public int? ArtifactArticleId { get; set; }  // Foreign Key to ArtifactArticle
        public ArtifactArticle? ArtifactArticle { get; set; }  // Navigation property
    }
}
