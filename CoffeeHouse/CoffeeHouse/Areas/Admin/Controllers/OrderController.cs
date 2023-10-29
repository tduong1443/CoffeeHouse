using CoffeeHouse.Data;
using CoffeeHouse.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHouse.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private CoffeeHouseContext db;
        public OrderController(CoffeeHouseContext db)
        {
            this.db = db;
        }
        public IActionResult Index(int? page)
        {
            var orders = db.Orders.ToList();

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
            int total = orders.Count();

            ViewBag.total = total;
            ViewBag.pageCurrent = page;

            float numberPage = (float)total / limit;
            ViewBag.numberPage = (int)Math.Ceiling(numberPage);
            var data = orders.OrderBy(c => c.IdOrders).Skip(start).Take(limit); ;
            return View(data);
        }

        // Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Orders orders)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(orders);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(orders);
        }

        // Edit
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = db.Orders.Find(id);
            if (orders == null)
            {
                return NotFound();
            }
            return View(orders);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Orders orders)
        {
            if (ModelState.IsValid)
            {
                db.Update(orders);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(orders);
        }

        // Delete
        public IActionResult Delete(int id)
        {
            var orders = db.Orders.Find(id);
            if (orders == null)
            {
                return NotFound();
            }
            return View(orders);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var orders = db.Orders.Find(id);
            if (orders == null)
            {
                return NotFound();
            }

            db.Orders.Remove(orders);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
