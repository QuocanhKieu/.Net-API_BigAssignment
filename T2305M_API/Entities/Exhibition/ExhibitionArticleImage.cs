using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2305M_API.Entities
{
    public class ExhibitionArticleImage
    {
        [Key]
        public int ExhibitionArticleImageId { get; set; }  // Primary Key
        public string ImageUrl { get; set; }  // URL to the imag
        [ForeignKey("ExhibitionArticle")]
        public int ExhibitionArticleId { get; set; }  // Foreign Key to ExhibitionArticl
        public ExhibitionArticle ExhibitionArticle { get; set; }  // Navigation property
    }
}
