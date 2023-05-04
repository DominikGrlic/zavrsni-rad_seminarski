using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using xyzWebApp.Data;
using xyzWebApp.Models;

namespace xyzWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
              return _context.Products != null ? 
                          View(await _context.Products.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Products'  is null.");
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            ViewBag.ErrorMsg = TempData["ErrorMsg"] as string ?? "";
            return View(nameof(Create));
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Sku,Title,Description,InStock,Price,Image")] Product product,
            int[] categoryIds,
            IFormFile Image)
        {
            // provjera parametra categoryIds[]
            if(categoryIds.Length == 0 || categoryIds == null)
            {
                // poruka za korisnika
                TempData["ErrorMsg"] = "Please, pick at least one category for your product.";
                // redirect
                return RedirectToAction(nameof(Create));
            }


            // pohrana prizvoda u tablicu i povezivanje s odredenom kategorijom
            if (ModelState.IsValid)
            {
                // spremanje slike na disk i naziva slike u product.Image
                try
                {
                    var imageName = Image.FileName.ToLower();

                    // putanja pohrane slike
                    // rezultat: /wwwroot/images/products/naziv-slike.jpg
                    var saveImagePath = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "wwwroot/images/products",
                            imageName
                        );

                    // kreiraj direktorije unutar putanje
                    Directory.CreateDirectory(Path.GetDirectoryName(saveImagePath));
                    // kopiranje datoteke unutar putanje
                    using (var stream = new FileStream(saveImagePath, FileMode.Create))
                    {
                        Image.CopyTo(stream);
                    }

                    product.Image = imageName;
                }
                catch(Exception ex)
                {
                    TempData["ErrorMsg"] = ex.Message;
                    return RedirectToAction(nameof(Create));
                }

                _context.Products.Add(product);
                //_context.Products.Add(product);          <--- jedna "od" varijanti za dodavanje u bazu
                await _context.SaveChangesAsync();
                //_context.SaveChanges();                  <--- kada nebi koristili "async" kodiranje
                


                // povezivanje product.Id sa categoryIds
                foreach(var categoryId in categoryIds)
                {
                    ProductCategory productCategory = new ProductCategory();
                    productCategory.CategoryId = categoryId;
                    productCategory.ProductId = product.Id;

                    _context.ProductCategories.Add(productCategory);
                }

                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Sku,Title,Description,InStock,Price,Image")] Product product, 
            IFormFile? newImage,
            int[] categoryIds)
        {
            if (id != product.Id)
            {
                return NotFound();
            }
            if(categoryIds.Length == 0)
            {
                TempData["ErrorMsg"] = "Molim odaberite jednu kategoriju!";
                return RedirectToAction(nameof(Edit), new { id = id });
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();

                    if(newImage != null)
                    {
                        var newImageName = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_" +
                            newImage.FileName.ToLower().Replace(" ", "_");

                        var saveImagePath = Path.Combine(
                                Directory.GetCurrentDirectory(),
                                "wwwroot/images/products",
                                newImageName
                            );

                        Directory.CreateDirectory(Path.GetDirectoryName(saveImagePath));
                        
                        using(var stream = new FileStream(saveImagePath, FileMode.Create))
                        {
                            newImage.CopyTo(stream);
                        }

                        product.Image = newImageName;

                    }

                    _context.Update(product);
                    await _context.SaveChangesAsync();

                    _context.ProductCategories.RemoveRange(_context.ProductCategories.Where(a=>a.ProductId == id));
                    _context.SaveChanges();

                    foreach(var category in categoryIds)
                    {
                        ProductCategory productCategory = new ProductCategory();
                        productCategory.ProductId = product.Id;
                        productCategory.CategoryId = category;

                        _context.Add(productCategory);
                    }

                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
