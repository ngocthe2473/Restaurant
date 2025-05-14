using Restaurant.Models;
using Restaurant.SessionSystem;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Components
{
	[ViewComponent(Name = "SidebarCategory")]
	public class SidebarCategoryComponent : ViewComponent
	{
		private readonly RestaurantContext _context;
		public SidebarCategoryComponent(RestaurantContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync(string type = "product")
		{
			var listCate = _context.Categories.AsNoTracking().OrderByDescending(m => m.CategoryId).Where(m => m.IsActive == true).ToList();

			if (type == "product")
			{
				listCate = listCate.Where(m => m.CategoryType == 2).ToList();
			} else
			{
				listCate = listCate.Where(m => m.CategoryType == 1).ToList();
			}
			ViewBag.type = type;
			return await Task.FromResult((IViewComponentResult)View("Default", listCate));
		}
	}
}
