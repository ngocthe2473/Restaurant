using Restaurant.Models;
using Restaurant.SessionSystem;
using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Components
{
	[ViewComponent(Name = "RelevantProduct")]
	public class RelevantProductComponent : ViewComponent
	{
		private readonly RestaurantContext _context;
		public RelevantProductComponent(RestaurantContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync(long ProductId, long CategoryId)
		{
			var listRelevantPorudct = _context.Products.OrderByDescending(m => m.ProductViewCount).Where(m => m.IsDeleted == false && m.IsActive == true && m.CategoryId == CategoryId && m.ProductId != ProductId).Take(4).ToList();
			return await Task.FromResult((IViewComponentResult)View("Default", listRelevantPorudct));
		}
	}
}
