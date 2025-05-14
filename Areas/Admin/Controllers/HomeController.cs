using ThuyTo.Models.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ThuyTo.Areas.Admin.Controllers
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
