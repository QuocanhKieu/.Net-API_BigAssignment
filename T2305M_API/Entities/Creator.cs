using System.ComponentModel.DataAnnotations;

namespace T2305M_API.Entities
{
    public class Creator
    {
        public int CreatorId { get; set; }  // Primary Key
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Nationality { get; set; }
        public string Avatar { get; set; }

        public bool IsActive { get; set; } = true; // Default to active
        public ICollection<Culture>? Cultures { get; set; } // Navigation property to Cultures
        public ICollection<Artifact>? Artifacts { get; set; } // Navigation property to Artifacts
        public ICollection<NationalEvent>? NationalEvents { get; set; } // Navigation property to National Events
        public ICollection<Exhibition>? Exhibitions { get; set; } // Navigation property to Exhibitions

        public ICollection<CultureArticle>? CultureArticle { get; set; } // Navigation property to Articles
        public ICollection<ArtifactArticle>? ArtifactArticle { get; set; } // Navigation property to Articles
        public ICollection<NationalEventArticle>? NationalEventArticle { get; set; } // Navigation property to Articles
        public ICollection<ExhibitionArticle>? ExhibitionArticle { get; set; } // Navigation property to Articles
    }
}
