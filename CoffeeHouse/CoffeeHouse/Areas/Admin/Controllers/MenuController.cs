using CoffeeHouse.Data;
using CoffeeHouse.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CoffeeHouse.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private CoffeeHouseContext db;
        public MenuController(CoffeeHouseContext db)
        {
            this.db = db;
        }
        public IActionResult Index(int? page)
        {
            var menu = db.Menu.Include(c => c.Category).ToList();

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
            int total = menu.Count();

            ViewBag.total = total;
            ViewBag.pageCurrent = page;

            float numberPage = (float)total / limit;
            ViewBag.numberPage = (int)Math.Ceiling(numberPage);
            var data = menu.OrderBy(c => c.Id).Skip(start).Take(limit); ;
            return View(data);
        }

        // Create
        public IActionResult Create()
        {
            Menu menu = new Menu();
            ViewBag.IdCategory = new SelectList(db.Categories, "IdCategory", "Name");
            return View(menu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Menu menu)
        {
            if (ModelState.IsValid)
            {
                if (menu.ImageUpload != null)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + menu.ImageUpload.FileName;
                    string uploadPath = Path.Combine("~/images_icon/menu/list_menu/", uniqueFileName);
                    string absolutePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images_icon/menu/list_menu", uniqueFileName);

                    using (var stream = new FileStream(absolutePath, FileMode.Create))
                    {
                        await menu.ImageUpload.CopyToAsync(stream);
                    }

                    menu.Image = uploadPath; // Lưu đường dẫn đến tệp mới với tên mới
                }
                db.Menu.Add(menu);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.IdCategory = new SelectList(db.Categories, "IdCategory", "Name");
            return View(menu);
        }

        // Edit
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = db.Menu.Find(id);
            if (menu == null)
            {
                return NotFound();
            }
            ViewBag.IdCategory = new SelectList(db.Categories, "IdCategory", "Name");
            return View(menu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Menu menu)
        {
            if (ModelState.IsValid)
            {
                if (menu.ImageUpload != null)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + menu.ImageUpload.FileName;
                    string uploadPath = Path.Combine("~/images_icon/menu/list_menu/", uniqueFileName);
                    string absolutePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images_icon/menu/list_menu", uniqueFileName);

                    using (var stream = new FileStream(absolutePath, FileMode.Create))
                    {
                        await menu.ImageUpload.CopyToAsync(stream);
                    }

                    menu.Image = uploadPath; // Lưu đường dẫn đến tệp mới với tên mới
                }
                db.Update(menu);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.IdCategory = new SelectList(db.Categories, "IdCategory", "Name");
            return View(menu);
        }

        // Delete
        public IActionResult Delete(string id)
        {
            var menu = db.Menu.Include(pro => pro.Category).FirstOrDefault(c => c.Id == id);
            if (menu == null)
            {
                return NotFound();
            }
            return View(menu);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var menu = db.Menu.Find(id);
            if (menu == null)
            {
                return NotFound();
            }

            db.Menu.Remove(menu);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
