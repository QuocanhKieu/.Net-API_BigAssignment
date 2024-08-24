using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2305M_API.Entities
{
    public class ExhibitionArticle
    {
        [Key]
        public int ExhibitionArticleId { get; set; }  // Primary Key

        [Required]
        [StringLength(200, ErrorMessage = "Title length can't be more than 200 characters.")]
        public string Title { get; set; }  // Title of the article

        [Required]
        public string Content { get; set; }  // Content of the article

        [ForeignKey("Exhibition")]
        public int ExhibitionId { get; set; }  // Foreign Key to Exhibition

        public Exhibition Exhibition { get; set; }  // Navigation property

        public ICollection<ExhibitionArticleImage>? ExhibitionArticleImages { get; set; }  // List of images related to the article
    }
}
