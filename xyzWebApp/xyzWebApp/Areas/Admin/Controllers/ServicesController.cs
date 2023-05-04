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
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Services
        public async Task<IActionResult> Index()
        {
              return _context.Services != null ? 
                          View(await _context.Services.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Services'  is null.");
        }

        // GET: Admin/Services/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Services == null)
            {
                return NotFound();
            }

            var service = await _context.Services
                .FirstOrDefaultAsync(m => m.Id == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // GET: Admin/Services/Create
        public IActionResult Create()
        {
            ViewBag.ErrorMsgCtgr = TempData["ErrorMsgCtgr"] as string ?? "";

            return View(nameof(Create));
        }

        // POST: Admin/Services/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Sku,Title,Description,Price,Image")] Service service,
            int[] categoryIds,
            IFormFile Image)
        {
            if(categoryIds.Length == 0 || categoryIds == null)
            {
                TempData["ErrorMsgCtgr"] = "Please, pick at least one category for your service.";
                return RedirectToAction(nameof(Create));
            }


            if (ModelState.IsValid)
            {
                try
                {
                    // spremanje slike, njenog naziva i putanje kod kreiranja nove usluge
                    var imageName = Image.FileName.ToLower();
                    var saveImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/services", imageName);

                    Directory.CreateDirectory(Path.GetDirectoryName(saveImagePath));

                    using (var stream = new FileStream(saveImagePath, FileMode.Create))
                        Image.CopyTo(stream);

                    service.Image = imageName;
                }
                catch (Exception ex)
                {
                    TempData["ErrorMsg"] = ex.Message;
                    return RedirectToAction(nameof(Create));
                }

                    _context.Services.Add(service);
                await _context.SaveChangesAsync();
                

                foreach(var categoryId in categoryIds)
                {
                    ServiceCategory serviceCategory = new ServiceCategory();
                    serviceCategory.CategoryId = categoryId;
                    serviceCategory.ServiceId = service.Id;

                    _context.ServiceCategories.Add(serviceCategory);
                }

                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Services/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Services == null)
            {
                return NotFound();
            }

            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        // POST: Admin/Services/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Sku,Title,Description,Price,Image")] Service service, 
            IFormFile? newImage,
            int[] categoryIds)
        {
            if (id != service.Id)
            {
                return NotFound();
            }
            if(categoryIds.Length == 0)
            {
                TempData["ErrorMsg"] = "Please pick one category!";
                return RedirectToAction(nameof(Edit), new { id = id });
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(service);
                    await _context.SaveChangesAsync();

                    if(newImage != null)                        
                    {
                        var newImageName = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_" +
                            newImage.FileName.ToLower().Replace(" ", "_");               // spremamo unikatan naziv slike
                        
                        var saveImagePath = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "wwwroot/images/services",                                  // stvaramo direktorij slike, ako ne postoji
                            newImageName
                            );

                        Directory.CreateDirectory(Path.GetDirectoryName(saveImagePath));

                        using (var stream = new FileStream(saveImagePath, FileMode.Create))
                        {
                            newImage.CopyTo(stream);
                        }

                        service.Image = newImageName;
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceExists(service.Id))
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
            return View(service);
        }

        // GET: Admin/Services/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Services == null)
            {
                return NotFound();
            }

            var service = await _context.Services
                .FirstOrDefaultAsync(m => m.Id == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // POST: Admin/Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Services == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Services'  is null.");
            }
            var service = await _context.Services.FindAsync(id);
            if (service != null)
            {
                _context.Services.Remove(service);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceExists(int id)
        {
          return (_context.Services?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
