

using System.ComponentModel.DataAnnotations;

namespace T2305M_API.Entities
{
    public class Category
    {
        [Key] // Specifies the primary key
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }

}
