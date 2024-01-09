using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var productVm = new ProductVM
            {
                Products = new List<Product>
                {
                    new Product { Id = 1, Name = "Product 1", UnitPrice = 10 },
                    new Product { Id = 2, Name = "Product 2", UnitPrice = 20 },
                    new Product { Id = 3, Name = "Product 3", UnitPrice = 30 },
                    new Product { Id = 4, Name = "Product 4", UnitPrice = 40 },
                    new Product { Id = 5, Name = "Product 5", UnitPrice = 50 },
                }
            };
            return View(productVm);
        }
        [HttpPost]
        public IActionResult Index(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                return View(productVM);
            }
            else
            {
                return BadRequest();
            }
        }


        public IActionResult Privacy()
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
