using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2305M_API.Entities
{
    public class CultureArticle
    {
        [Key]
        public int CultureArticleId { get; set; }  // Primary Key
        public string Title { get; set; }  // Title of the article
        public string Content { get; set; }  // Content of the article
        public string ThumbnailImage { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;

        [ForeignKey("Culture")]
        public int? CultureId { get; set; }  // Foreign Key to Culture
        public Culture? Culture { get; set; }  // Navigation property

        [ForeignKey("Creator")]
        public int? CreatorId { get; set; }  // Foreign Key to Creator
        public Creator? Creator { get; set; }  // Navigation property

        public ICollection<CultureArticleImage>? CultureArticleImages { get; set; }  // List of images related to the article
    }
}
