using CoffeeHouse.Data;
using CoffeeHouse.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHouse.Controllers
{
    public class CartController : Controller
    {

        // Add to cart
        private CoffeeHouseContext db;
        public CartController(CoffeeHouseContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            List<ShopCart> item = HttpContext.Session.GetJson<List<ShopCart>>("Cart") ?? new List<ShopCart>();
            CartItem cart = new()
            {
                Item = item,
                GrandTotal = item.Sum(x => x.Quantity * x.Price)
            };
            return View(cart);
        }

        public IActionResult Add(string id)
        {
            return View();
        }
    }
}
