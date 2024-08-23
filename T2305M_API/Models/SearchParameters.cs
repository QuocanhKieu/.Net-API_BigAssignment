namespace T2305M_API.Models
{


    public class SearchParameters
    {
        public string? Query { get; set; } // General search term
        public string? Sections { get; set; } // Sections to search in
        public string? Sort { get; set; } // Sorting order
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}