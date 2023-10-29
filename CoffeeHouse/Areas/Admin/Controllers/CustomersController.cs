using CoffeeHouse.Data;
using CoffeeHouse.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHouse.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomersController : Controller
    {
        private CoffeeHouseContext db;
        public CustomersController(CoffeeHouseContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var customers = db.Customers.ToList();
            return View(customers);
        }

        // Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // Edit
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = db.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Update(customer);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // Delete
        public IActionResult Delete(int id)
        {
            var customer = db.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var customer = db.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
