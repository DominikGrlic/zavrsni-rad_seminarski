using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Index(string? srchTab, int srchPar = 0, int categoryId = 0)
        {
            List<Product> products = _dbContext.Products.ToList();
            Random rnd = new Random();                                      // ugradena klasa
            products = products.OrderBy(a => rnd.Next()).Take(10).ToList();


            if (!String.IsNullOrEmpty(srchTab))
            {
                products = products.Where(a=>a.Title.ToLower().Contains(srchTab.ToLower())).ToList();
            }

            switch(srchPar)
            {
                case 1: products = products.OrderBy(a=>a.Price).ToList(); break;
                case 2: products = products.OrderByDescending(a=>a.Price).ToList(); break;
                case 3: products = products.OrderBy(a=>a.Title).ToList(); break;
                case 4: products = products.OrderByDescending(a=>a.Title).ToList(); break;
            }

            if (categoryId > 0)
                products = _dbContext.Products.Where(a=>_dbContext.ProductCategories.Where(a=>a.CategoryId == categoryId
                        ).Select(a=>a.ProductId).ToList().Contains(a.Id)).ToList();

            ViewBag.Categories = _dbContext.Categories.ToList();

            return View(products);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _dbContext.Products == null)
            {
                return NotFound();
            }

            var product = await _dbContext.Products.FirstOrDefaultAsync(a => a.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // TODO:
        public IActionResult ProductsByCategories(int id)
        {
            if (id <= 0)
                return NotFound();

            List<Product> prodPerCat = _dbContext.Products.Where(a => _dbContext.ProductCategories.Where(a => a.CategoryId == id).Select(a => a.ProductId).ToList().Contains(a.Id)).ToList();

            if (prodPerCat == null)
                return NotFound();

            return View(prodPerCat);
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