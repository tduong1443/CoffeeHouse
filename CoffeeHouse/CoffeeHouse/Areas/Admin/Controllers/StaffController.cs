using CoffeeHouse.Data;
using CoffeeHouse.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHouse.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StaffController : Controller
    {
        private CoffeeHouseContext db;
        public StaffController(CoffeeHouseContext db)
        {
            this.db = db;
        }
        public IActionResult Index(int? page)
        {
            var staffs = db.Staff.ToList();
            // Paging

            if (page > 0)
            {
                page = page;
            }
            else
            {
                page = 1;
            }

            int limit = 2; // Số sản phẩm trong 1 trang
            int start = (int)(page - 1) * limit;
            int totalProducts = staffs.Count();

            ViewBag.totalProducts = totalProducts;
            ViewBag.pageCurrent = page;

            float numberPage = (float)totalProducts / limit;
            ViewBag.numberPage = (int)Math.Ceiling(numberPage);
            var dataStaff = staffs.OrderBy(c => c.IdStaff).Skip(start).Take(limit); ;
            return View(dataStaff);
        }

        // Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Staff.Add(staff);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }

        // Edit
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = db.Staff.Find(id);
            if (staff == null)
            {
                return NotFound();
            }
            return View(staff);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Update(staff);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }

        // Delete
        public IActionResult Delete(int id)
        {
            var staff = db.Staff.Find(id);
            if (staff == null)
            {
                return NotFound();
            }
            return View(staff);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var staff = db.Staff.Find(id);
            if (staff == null)
            {
                return NotFound();
            }

            db.Staff.Remove(staff);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
