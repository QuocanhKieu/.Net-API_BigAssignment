using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2305M_API.Entities
{
    public class CultureArticleImage
    {
        [Key]
        public int CultureArticleImageId { get; set; }  // Primary Key

        [Required]
        [StringLength(255, ErrorMessage = "Image URL length can't be more than 255 characters.")]
        public string ImageUrl { get; set; }  // URL to the image

        [ForeignKey("CultureArticle")]
        public int CultureArticleId { get; set; }  // Foreign Key to CultureArticle

        public CultureArticle CultureArticle { get; set; }  // Navigation property
    }
}
