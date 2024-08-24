using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2305M_API.Entities
{
    public class ArtArticleImage
    {
        [Key]
        public int ArtArticleImageId { get; set; }  // Primary Key

        [Required]
        [StringLength(255)]  // Assuming a reasonable max length for URLs
        public string ImageUrl { get; set; }  // URL to the image

        [ForeignKey("ArtArticle")]
        public int ArtArticleId { get; set; }  // Foreign Key to ArtArticle

        public ArtArticle ArtArticle { get; set; }  // Navigation property
    }
}
