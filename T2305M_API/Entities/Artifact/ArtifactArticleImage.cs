using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2305M_API.Entities
{
    public class ArtifactArticleImage
    {
        [Key]
        public int ArtifactArticleImageId { get; set; }  // Primary Key

        [Required]
        [StringLength(255, ErrorMessage = "ImageUrl length can't be more than 255 characters.")]
        public string ImageUrl { get; set; }  // URL to the image

        [StringLength(255, ErrorMessage = "Thumbnail length can't be more than 255 characters.")]
        public string? Thumbnail { get; set; }  // Optional Thumbnail URL

        [ForeignKey("ArtifactArticle")]
        public int ArtifactArticleId { get; set; }  // Foreign Key to ArtifactArticle

        public ArtifactArticle ArtifactArticle { get; set; }  // Navigation property
    }
}
