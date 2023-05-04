using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using xyzWebApp.Data;
using xyzWebApp.Models;

namespace xyzWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index(string? srchTab, int? srchPar)
        {
            List<Product> products = _dbContext.Products.OrderBy(a=>a.Title).ToList();

            if(!String.IsNullOrEmpty(srchTab))
            {
                products = products.Where(a=>a.Title.Contains(srchTab.ToLower())).ToList();
            }

            switch(srchPar)
            {
                case 1: products = products.OrderBy(a=>a.Price).ToList(); break;
                case 2: products = products.OrderByDescending(a=>a.Price).ToList(); break;
            }

            return View(products);
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