using CoffeeHouse.Data;
using CoffeeHouse.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHouse.Controllers
{
    public class MenuController : Controller
    {
        public CoffeeHouseContext db;
        public MenuController(CoffeeHouseContext db)
        {
            this.db = db;
        }
        public IActionResult Menu(int? page)
        {
            var listMenu = db.Menu.ToList();

            if (page > 0)
            {
                page = page;
            }
            else
            {
                page = 1;
            }

            int limit = 6; // Số sản phẩm trong 1 trang
            int start = (int)(page - 1) * limit;
            int total = listMenu.Count();

            ViewBag.totalProducts = total;
            ViewBag.pageCurrent = page;

            float numberPage = (float)total / limit;
            ViewBag.numberPage = (int)Math.Ceiling(numberPage);
            var dataProducts = listMenu.OrderBy(c => c.Id).Skip(start).Take(limit); ;
            return View(dataProducts);
        }
        public IActionResult MenuProducts(string id, int? page) 
        {
            List<Menu> lst = db.Menu.Where(x => x.IdCategory == id).OrderBy(x => x.Name).ToList();

            if (page > 0)
            {
                page = page;
            }
            else
            {
                page = 1;
            }

            int limit = 3; // Số sản phẩm trong 1 trang
            int start = (int)(page - 1) * limit;
            int total = lst.Count();

            ViewBag.total = total;
            ViewBag.pageCurrent = page;

            float numberPage = (float)total / limit;
            ViewBag.numberPage = (int)Math.Ceiling(numberPage);
            var data = lst.OrderBy(c => c.Id).Skip(start).Take(limit); ;
            return View(data);
        }
    }
}
