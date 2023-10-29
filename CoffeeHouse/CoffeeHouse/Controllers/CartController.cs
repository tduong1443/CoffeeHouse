using CoffeeHouse.Data;
using CoffeeHouse.Models;
using Microsoft.AspNetCore.Authorization;
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
            var isLoggedIn = HttpContext.Session.GetString("IsLoggedIn");

            if (!string.IsNullOrEmpty(isLoggedIn) && isLoggedIn == "true")
            {
                List<ShopCart> item = HttpContext.Session.GetJson<List<ShopCart>>("Cart") ?? new List<ShopCart>();
                CartItem cart = new()
                {
                    Item = item,
                    GrandTotal = item.Sum(x => x.Quantity * x.Price)
                };
                return View(cart);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public async Task<IActionResult> Add(string id)
        {
            var isLoggedIn = HttpContext.Session.GetString("IsLoggedIn");

            if (!string.IsNullOrEmpty(isLoggedIn) && isLoggedIn == "true")
            {
                Products products = await db.Products.FindAsync(id);
                List<ShopCart> item = HttpContext.Session.GetJson<List<ShopCart>>("Cart") ?? new List<ShopCart>();
                ShopCart cart = item.Where(p => p.Id == id).FirstOrDefault();

                if (cart == null)
                {
                    item.Add(new ShopCart(products));
                }
                else
                {
                    cart.Quantity += 1;
                }
                HttpContext.Session.SetJson("Cart", item);
                return Redirect(Request.Headers["Referer"].ToString());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public async Task<IActionResult> Decrease(string id)
        {
            List<ShopCart> item = HttpContext.Session.GetJson<List<ShopCart>>("Cart") ?? new List<ShopCart>();

            ShopCart cart = item.Where(p => p.Id == id).FirstOrDefault();

            if(cart.Quantity > 1)
            {
                --cart.Quantity;
            }
            else
            {
                item.RemoveAll(p => p.Id == id);
            }

            if(item.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", item);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Increase(string id)
        {
            List<ShopCart> item = HttpContext.Session.GetJson<List<ShopCart>>("Cart") ?? new List<ShopCart>();

            ShopCart cart = item.Where(p => p.Id == id).FirstOrDefault();

            if (cart.Quantity > 1)
            {
                cart.Quantity++;
            }

            HttpContext.Session.SetJson("Cart", item);
            return RedirectToAction("Index");
        }
    }
}
