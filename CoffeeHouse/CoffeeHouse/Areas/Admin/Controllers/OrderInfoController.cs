using CoffeeHouse.Data;
using CoffeeHouse.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHouse.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderInfoController : Controller
    {
        private CoffeeHouseContext db;
        public OrderInfoController(CoffeeHouseContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var orderInfo = db.OrdersInfo.ToList();
            return View(orderInfo);
        }

        // Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OrderInfo orderInfo)
        {
            if (ModelState.IsValid)
            {
                db.OrdersInfo.Add(orderInfo);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(orderInfo);
        }

        // Edit
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderInfo = db.OrdersInfo.Find(id);
            if (orderInfo == null)
            {
                return NotFound();
            }
            return View(orderInfo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(OrderInfo orderInfo)
        {
            if (ModelState.IsValid)
            {
                db.Update(orderInfo);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(orderInfo);
        }

        // Delete
        public IActionResult Delete(string id)
        {
            var orderInfo = db.OrdersInfo.Find(id);
            if (orderInfo == null)
            {
                return NotFound();
            }
            return View(orderInfo);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var orderInfo = db.OrdersInfo.Find(id);
            if (orderInfo == null)
            {
                return NotFound();
            }

            db.OrdersInfo.Remove(orderInfo);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
