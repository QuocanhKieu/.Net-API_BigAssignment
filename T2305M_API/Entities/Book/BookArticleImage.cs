using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2305M_API.Entities
{
    public class BookArticleImage
    {
        [Key]
        public int BookArticleImageId { get; set; }  // Primary Key

        [Required]
        [StringLength(255, ErrorMessage = "Image URL length can't be more than 255 characters.")]
        public string ImageUrl { get; set; }  // URL to the image

        [ForeignKey("BookArticle")]
        public int BookArticleId { get; set; }  // Foreign Key to BookArticle

        public BookArticle BookArticle { get; set; }  // Navigation property
    }
}
