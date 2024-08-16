namespace T2305M_API.Entities
{
    public class Artifact
    {
        public int ArtifactId { get; set; } // Primary Key
        public string Thumbnail { get; set; } // Thumbnail image
        public string Name { get; set; }
        public string Origin { get; set; }
        public DateTime DateDiscovered { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; } // Foreign Key
        public Category Category { get; set; }
        public bool IsActive { get; set; } // Active/Inactive status
    }

}
