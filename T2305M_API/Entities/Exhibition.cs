namespace T2305M_API.Entities
{
    public class Exhibition
    {
        public int ExhibitionId { get; set; } // Primary Key
        public string Thumbnail { get; set; } // Thumbnail image
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Curator { get; set; }
        public bool IsActive { get; set; } // Active/Inactive status
    }

}
