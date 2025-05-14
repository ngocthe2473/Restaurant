using Restaurant.Models;
using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Controllers
{
	public class ErrorController : Controller
	{
		private readonly RestaurantContext _context;
		public ErrorController(RestaurantContext context) 
		{ 
			_context = context; 
		}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult ErrorRole()
		{
			return View();
		}
	}
}
