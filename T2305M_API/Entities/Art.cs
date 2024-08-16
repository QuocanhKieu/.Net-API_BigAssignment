namespace T2305M_API.Entities
{
    public class Art
    {
        public int ArtId { get; set; } // Primary Key
        public string Thumbnail { get; set; } // Thumbnail image
        public string Name { get; set; }
        public string Style { get; set; }
        public string Period { get; set; }
        public string NotableArtists { get; set; }
        public int CategoryId { get; set; } // Foreign Key
        public Category Category { get; set; }
        public bool IsActive { get; set; } // Active/Inactive status
    }

}
