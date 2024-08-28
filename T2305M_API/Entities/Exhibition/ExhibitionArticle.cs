using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2305M_API.Entities
{
    public class ExhibitionArticle
    {
        [Key]
        public int ExhibitionArticleId { get; set; }  // Primary Key
        public string Title { get; set; }  // Title of the article
        public string Content { get; set; }  // Content of the article
        public string ThumbnailImage { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;

        [ForeignKey("Exhibition")]
        public int? ExhibitionId { get; set; }  // Foreign Key to Exhibition
        public Exhibition? Exhibition { get; set; }  // Navigation property
        public ICollection<ExhibitionArticleImage>? ExhibitionArticleImages { get; set; }  // List of images related to the article
        [ForeignKey("Creator")]
        public int? CreatorId { get; set; }  // Foreign Key to Creator
        public Creator? Creator { get; set; }  // Navigation property
    }
}
