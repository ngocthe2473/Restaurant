using Restaurant.Models;
using Restaurant.SessionSystem;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Components
{
	[ViewComponent(Name = "NewProduct")]
	public class NewProductComponent : ViewComponent
	{
		private readonly RestaurantContext _context;
		public NewProductComponent(RestaurantContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var listNewProduct = _context.Products.AsNoTracking().OrderByDescending(m => m.ProductViewCount).Where(m => m.IsActive == true && m.IsDeleted == false).Include(m => m.Category).Take(8).ToList();
			return await Task.FromResult((IViewComponentResult)View("Default", listNewProduct));
		}
	}
}
