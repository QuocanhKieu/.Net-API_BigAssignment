using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace T2305M_MVC.Entities
{
	[Table("products")]
	public class Product
	{
		// id, name, price, description, category_id(FK)
		[Key]
        [Column(name:"id")]
        public int Id { get; set; }

		[Required]
		[Column(name:"name")]
		public string Name { get; set; }

		[Required]
		[Column(name:"price")]
		public double Price { get; set; }

		[Column(name:"description", TypeName = "text")]
		public string Description { get; set; }

		//[Column(name:"category_id")]
		//[Required]
		//public int CategoryId { get; set; }

		[ForeignKey("category_id")]
		[Required]
		public Category Category { get; set; }
	}
}

