using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2305M_API.Entities
{
    public class ExhibitionArticleImage
    {
        [Key]
        public int ExhibitionArticleImageId { get; set; }  // Primary Key

        [Required]
        [StringLength(255, ErrorMessage = "Image URL length can't be more than 255 characters.")]
        public string ImageUrl { get; set; }  // URL to the image

        [ForeignKey("ExhibitionArticle")]
        public int ExhibitionArticleId { get; set; }  // Foreign Key to ExhibitionArticle

        public ExhibitionArticle ExhibitionArticle { get; set; }  // Navigation property
    }
}
