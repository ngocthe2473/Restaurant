using Restaurant.Models;
using Restaurant.SessionSystem;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Components
{
	[ViewComponent(Name = "BestSellerProduct")]
	public class BestSellerProductComponent : ViewComponent
	{
		private readonly RestaurantContext _context;
		public BestSellerProductComponent(RestaurantContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var listBestSellerProduct = _context.Products.AsNoTracking().Where(m => m.IsBestSeller == true && m.IsActive == true && m.IsDeleted == false).Include(m => m.Category).Take(10).ToList();
			return await Task.FromResult((IViewComponentResult)View("Default", listBestSellerProduct));
		}
	}
}
