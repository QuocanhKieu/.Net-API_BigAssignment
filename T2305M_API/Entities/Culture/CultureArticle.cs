using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2305M_API.Entities
{
    public class CultureArticle
    {
        [Key]
        public int CultureArticleId { get; set; }  // Primary Key

        [Required]
        [StringLength(200, ErrorMessage = "Title length can't be more than 200 characters.")]
        public string Title { get; set; }  // Title of the article

        [Required]
        public string Content { get; set; }  // Content of the article

        [ForeignKey("Culture")]
        public int CultureId { get; set; }  // Foreign Key to Culture

        public Culture Culture { get; set; }  // Navigation property

        public ICollection<CultureArticleImage>? CultureArticleImages { get; set; }  // List of images related to the article
    }
}
