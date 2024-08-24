using System.ComponentModel.DataAnnotations;

namespace T2305M_API.Entities
{
    public class Creator
    {
        public int CreatorId { get; set; }  // Primary Key

        [Required]
        [StringLength(100)]  // Simplified length constraint for the name

        public string Name { get; set; }

        [StringLength(500)]  // Simplified length constraint for the bio
        public string Bio { get; set; }

        [StringLength(50)]  // Simplified length constraint for the nationality
        public string Nationality { get; set; }

        [StringLength(255)]  // Simplified length constraint for the image URL or path
        public string Image { get; set; }

        public bool IsActive { get; set; } = true; // Default to active

        public ICollection<Art>? Arts { get; set; } // Navigation property to Art Articles
        public ICollection<Culture>? Cultures { get; set; } // Navigation property to Cultures
        public ICollection<Book>? Books { get; set; } // Navigation property to Books
        public ICollection<Artifact>? Artifacts { get; set; } // Navigation property to Artifacts
        public ICollection<NationalEvent>? NationalEvents { get; set; } // Navigation property to National Events
        public ICollection<Exhibition>? Exhibitions { get; set; } // Navigation property to Exhibitions

        public ICollection<CultureArticle>? CultureArticle { get; set; } // Navigation property to Articles
        public ICollection<ArtifactArticle>? ArtifactArticle { get; set; } // Navigation property to Articles
        public ICollection<BookArticle>? BookArticle { get; set; } // Navigation property to Articles
        public ICollection<NationalEventArticle>? NationalEventArticle { get; set; } // Navigation property to Articles
        public ICollection<ExhibitionArticle>? ExhibitionArticle { get; set; } // Navigation property to Articles
        public ICollection<ArtArticle>? ArtArticle { get; set; } // Navigation property to Articles
    }
}
