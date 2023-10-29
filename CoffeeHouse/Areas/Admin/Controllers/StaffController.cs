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
        public IActionResult Index()
        {
            var staffs = db.Staff.ToList();
            return View(staffs);
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
