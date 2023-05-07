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
        //[HttpPost]
        public IActionResult ProductsByCategories(int id)
        {
            if (id < 0)
                return NotFound();

            List<Product> prodPerCat = _dbContext.Products.Where(a => _dbContext.ProductCategories.Where(a => a.CategoryId == id).Select(a => a.ProductId).ToList().Contains(a.Id)).ToList();

            if (prodPerCat == null)
            {
                TempData["EmpytList"] = "This list is currently empty. Try again soon!";
                return NotFound();
            }

            ViewBag.EmptyList = TempData["EmptyList"] as string ?? "";

            return View(prodPerCat);
        }

        public IActionResult Services(string? srchTab, int srchPar = 0)
        {
            List<Service> services = _dbContext.Services.ToList();
            Random rnd = new Random();                                      // ugradena klasa
            services = services.OrderBy(a => rnd.Next()).Take(10).ToList();


            if (!String.IsNullOrEmpty(srchTab))
            {
                services = services.Where(a => a.Title.ToLower().Contains(srchTab.ToLower())).ToList();
            }

            switch (srchPar)
            {
                case 1: services = services.OrderBy(a => a.Price).ToList(); break;
                case 2: services = services.OrderByDescending(a => a.Price).ToList(); break;
                case 3: services = services.OrderBy(a => a.Title).ToList(); break;
                case 4: services = services.OrderByDescending(a => a.Title).ToList(); break;
            }

            ViewBag.Categories = _dbContext.Categories.ToList();

            return View(services);
        }

        public async Task<IActionResult> ServiceDetails(int? id)
        {
            if (id == null || _dbContext.Services == null)
            {
                return NotFound();
            }

            var service = await _dbContext.Services.FirstOrDefaultAsync(a => a.Id == id);

            if (service == null)
            {
                return NotFound();
            }

            return View(service);
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