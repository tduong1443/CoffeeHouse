using CoffeeHouse.Data;
using CoffeeHouse.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHouse.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private CoffeeHouseContext db;
        public CategoryController(CoffeeHouseContext db)
        {
            this.db = db;
        }
        public IActionResult Index(int? page)
        {
            var category = db.Categories.ToList();
            // Paging

            if (page > 0)
            {
                page = page;
            }
            else
            {
                page = 1;
            }

            int limit = 4; // Số sản phẩm trong 1 trang
            int start = (int)(page - 1) * limit;
            int totalProducts = category.Count();

            ViewBag.totalProducts = totalProducts;
            ViewBag.pageCurrent = page;

            float numberPage = (float)totalProducts / limit;
            ViewBag.numberPage = (int)Math.Ceiling(numberPage);
            var dataCategory = category.OrderBy(c => c.IdCategory).Skip(start).Take(limit); ;
            return View(dataCategory);
        }

        // Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // Edit
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Update(category);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // Delete
        public IActionResult Delete(string id)
        {
            var category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
