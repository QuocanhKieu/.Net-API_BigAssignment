using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace T2305M_MVC.Entities
{
	[Table("categories")]
	public class Category
	{
		[Key]
		[Column(name:"id")]
		public int Id { get; set; } // abstract property

		[Column(name:"name")]
		[Required]
		public string Name { get; set; }
	}
}

