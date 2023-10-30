using CoffeeHouse.Data;
using CoffeeHouse.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CoffeeHouse.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private CoffeeHouseContext db;
        public ProductsController(CoffeeHouseContext db)
        {
            this.db = db;
        }
        public IActionResult Index(int? page)
        {
            var products = db.Products.Include(c => c.Category).ToList();

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
            int totalProducts = products.Count();

            ViewBag.totalProducts = totalProducts;
            ViewBag.pageCurrent = page;

            float numberPage = (float)totalProducts / limit;
            ViewBag.numberPage = (int)Math.Ceiling(numberPage);
            var dataProducts = products.OrderBy(c => c.IdProduct).Skip(start).Take(limit); ;
            return View(dataProducts);
        }

        // Create
        public IActionResult Create()
        {
            Products products = new Products();
            ViewBag.IdCategory = new SelectList(db.Categories, "IdCategory", "Name");
            return View(products);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Products products)
        {
            if (ModelState.IsValid)
            {
                if (products.ImageUpload != null)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + products.ImageUpload.FileName;
                    string uploadPath = Path.Combine("~/images_icon/menu/list_menu/", uniqueFileName);
                    string absolutePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images_icon/menu/list_menu", uniqueFileName);

                    using (var stream = new FileStream(absolutePath, FileMode.Create))
                    {
                        await products.ImageUpload.CopyToAsync(stream);
                    }

                    products.Image = uploadPath; // Lưu đường dẫn đến tệp mới với tên mới
                }
                db.Products.Add(products);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.IdCategory = new SelectList(db.Categories, "IdCategory", "Name");
            return View(products);
        }

        // Edit
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = db.Products.Find(id);
            if (products == null)
            {
                return NotFound();
            }
            ViewBag.IdCategory = new SelectList(db.Categories, "IdCategory", "Name");
            return View(products);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Products products)
        {
            if (ModelState.IsValid)
            {
                if (products.ImageUpload != null)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + products.ImageUpload.FileName;
                    string uploadPath = Path.Combine("~/images_icon/menu/list_menu/", uniqueFileName);
                    string absolutePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images_icon/menu/list_menu", uniqueFileName);

                    using (var stream = new FileStream(absolutePath, FileMode.Create))
                    {
                        await products.ImageUpload.CopyToAsync(stream);
                    }

                    products.Image = uploadPath; // Lưu đường dẫn đến tệp mới với tên mới
                }
                db.Update(products);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.IdCategory = new SelectList(db.Categories, "IdCategory", "Name");
            return View(products);
        }

        // Delete
        public IActionResult Delete(string id)
        {
            var products = db.Products.Include(pro => pro.Category).FirstOrDefault(c => c.IdProduct == id);
            if (products == null)
            {
                return NotFound();
            }
            return View(products);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var products = db.Products.Find(id);
            if (products == null)
            {
                return NotFound();
            }

            db.Products.Remove(products);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
