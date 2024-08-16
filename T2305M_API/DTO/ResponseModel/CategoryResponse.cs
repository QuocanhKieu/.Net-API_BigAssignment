using System;
using T2305M_API.Entities;
namespace T2305M_API.DTO.ResponseModel
{
	public class CategoryResponse
	{
		public CategoryResponse(Category category)
		{
			//id = category.Id;
			//name = category.Name;
		}

		public int id { get; set; }
		public string name { get; set; }

		public static List<CategoryResponse> BuildCategoryList(List<Category> ls)
		{
			return null;
		}
	}
}

