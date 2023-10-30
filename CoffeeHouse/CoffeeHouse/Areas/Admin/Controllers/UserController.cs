using CoffeeHouse.Data;
using CoffeeHouse.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHouse.Areas.Admin.Controllers
{
    [Area("Admin")]
//    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private CoffeeHouseContext db;
        public UserController(CoffeeHouseContext db)
        {
            this.db = db;
        }
        public IActionResult Index(int? page)
        {
            var users = db.Users.ToList();

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
            int total = users.Count();

            ViewBag.total = total;
            ViewBag.pageCurrent = page;

            float numberPage = (float)total / limit;
            ViewBag.numberPage = (int)Math.Ceiling(numberPage);
            var data = users.OrderBy(c => c.Username).Skip(start).Take(limit); ;
            return View(data);
          
        }

        // Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(Users users)
        //{
        //    if (User.IsInRole("Admin"))
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Users.Add(users);
        //            db.SaveChanges();
        //            return RedirectToAction(nameof(Index));
        //        }
        //        return View(users);
        //    }
        //    else
        //    {
        //        return Forbid(); // Hoặc chuyển hướng đến trang Access Denied
        //    }
        //}


        //// Edit
        //public IActionResult Edit(string username)
        //{
        //    if (username == null)
        //    {
        //        return NotFound();
        //    }

        //    var users = db.Users.Find(username);
        //    if (users == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(users);
        //}

        
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(Users users)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Update(users);
        //        db.SaveChanges();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(users);
        //}

        //// Delete
        //public IActionResult Delete(string username)
        //{
        //    var users = db.Users.Find(username);
        //    if (users == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(users);

        //}
        
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeleteConfirmed(string username)
        //{
        //    var users = db.Users.Find(username);
        //    if (users == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Users.Remove(users);
        //    db.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
