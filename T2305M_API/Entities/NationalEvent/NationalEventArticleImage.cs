using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2305M_API.Entities
{
    public class NationalEventArticleImage
    {
        [Key]
        public int NationalEventArticleImageId { get; set; }  // Primary Key
        public string ImageUrl { get; set; }  // URL to the image

        [ForeignKey("NationalEventArticle")]
        public int? NationalEventArticleId { get; set; }  // Foreign Key to NationalEventArticle
        public NationalEventArticle? NationalEventArticle { get; set; }  // Navigation property
    }
}
