using Restaurant.Models;
using Restaurant.Models.Authentication;
using Restaurant.SessionSystem;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RestaurantContext _context;
        public HomeController(ILogger<HomeController> logger, RestaurantContext context)
        {
            _logger = logger;
            _context = context;

		}

        /*[CustomerAuthentication]*/
        public IActionResult Index()
        {
            var listProduct = _context.Products.OrderByDescending(m => m.ProductViewCount).Take(30).ToList();
            ViewBag.ListBestSellerProduct = listProduct.Where(m => m.IsBestSeller == true && m.IsActive == true && m.IsDeleted == false);
			ViewBag.ListNewProduct = listProduct.Where(m => m.IsActive == true && m.IsDeleted == false).Take(8).ToList();
			return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Route("/NotFound")]
        public IActionResult PageNotFound()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}