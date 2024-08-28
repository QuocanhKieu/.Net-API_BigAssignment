using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2305M_API.Entities
{
    public class ExhibitionImage
    {
        [Key]
        public int ExhibitionImageId { get; set; }  // Primary Key
        public string ImageUrl { get; set; }  // URL to the image
        [ForeignKey("Exhibition")]
        public int ExhibitionId { get; set; }  // Foreign Key to Exhibition
        public Exhibition Exhibition { get; set; }  // Navigation property
    }
}
