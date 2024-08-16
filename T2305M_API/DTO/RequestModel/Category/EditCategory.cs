using System;
using System.ComponentModel.DataAnnotations;
namespace T2305M_API.DTO.RequestModel.Category
{
	public class EditCategory
	{
        [Required]
        public int id { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        [MinLength(3, ErrorMessage = "Min length of name is 3 characters")]
        public string name { get; set; }
    }
}

