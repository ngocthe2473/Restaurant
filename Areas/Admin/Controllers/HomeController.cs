using Restaurant.Models.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Areas.Admin.Controllers
{
	[Area("Admin")]
    [AdminAuthentication]

    public class HomeController : Controller
	{

		public IActionResult Index()
		{
			return View();
		}
	}
}
