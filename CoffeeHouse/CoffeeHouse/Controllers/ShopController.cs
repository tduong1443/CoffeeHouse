using Azure;
using CoffeeHouse.Data;
using CoffeeHouse.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PagedList;

namespace CoffeeHouse.Controllers
{
    public class ShopController : Controller
    {
        public CoffeeHouseContext db;
        public ShopController(CoffeeHouseContext db)
        {
            this.db = db;
        }
     
        public IActionResult Shop(int? page)
        {
            var listProducts = db.Products.ToList();

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
            int totalProducts = listProducts.Count();

            ViewBag.totalProducts = totalProducts;
            ViewBag.pageCurrent = page;

            float numberPage = (float)totalProducts / limit;
            ViewBag.numberPage = (int)Math.Ceiling(numberPage);
            var dataProducts = listProducts.OrderBy(c => c.IdProduct).Skip(start).Take(limit); ;
            return View(dataProducts);
        }

        public IActionResult ShopProducts(string id)
        {
            List<Products> lst = db.Products.Where(x => x.IdProduct == id).OrderBy(x => x.Name).ToList();

            return View(lst);
        }
    }
}
