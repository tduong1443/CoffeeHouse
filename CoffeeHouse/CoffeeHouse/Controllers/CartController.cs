using CoffeeHouse.Data;
using CoffeeHouse.Models;
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
            // kiểm tra người dùng đã đăng nhập hay chưa
            var isLoggedIn = HttpContext.Session.GetString("IsLoggedIn");

            // nếu người dùng đã đăng nhập --> lấy thông tin của ior hàng --> trả về trang giỏ hàng
            if (!string.IsNullOrEmpty(isLoggedIn) && isLoggedIn == "true")
            {
                // lấy thông tin giỏ hàng từ session --> nếu giỏ hàng chưa đc tạo --> trả về danh sách rỗng
                List<ShopCart> item = HttpContext.Session.GetJson<List<ShopCart>>("Cart") ?? new List<ShopCart>();
                CartItem cart = new()
                {
                    Item = item,
                    GrandTotal = item.Sum(x => x.Quantity * x.Price) // tính tổng giá trị của tất cả sp trong giỏ hàng
                };
                return View(cart);
            }
            // nếu chưa đăng nhập --> trả về trang login
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public async Task<IActionResult> Add(string id)
        {
            var isLoggedIn = HttpContext.Session.GetString("IsLoggedIn");

            // kiểm tra đăng nhập người dùng
            if (!string.IsNullOrEmpty(isLoggedIn) && isLoggedIn == "true")
            {
                // tìm sản phẩm voiwss id được truyền vào --> nếu tìm được --> trả về sản phẩm tương ứng trong csdl
                Products products = await db.Products.FindAsync(id);

                // lấy danh sách sp trong giỏ hàng từ session, nếu giỏ hàng ko tồn tại thì tạo 1 giỏ hàng trống
                List<ShopCart> item = HttpContext.Session.GetJson<List<ShopCart>>("Cart") ?? new List<ShopCart>();

                // tìm sản phẩm với id --> tìm thấy gán giá trị cart --> ko tìm thấy cart = null
                ShopCart cart = item.Where(p => p.Id == id).FirstOrDefault();

                // nếu sp chưa được thêm vào giỏ hàng thì sẽ thêm mới
                if (cart == null)
                {
                    item.Add(new ShopCart(products));
                }

                // nếu sp đã có trong giỏ hàng thì sẽ tăng số lượng lên 1
                else
                {
                    cart.Quantity += 1;
                }
                // cập nhật ds giỏ hàng trong sesion
                HttpContext.Session.SetJson("Cart", item);

                // chuyển người dùng trở lại trang trước đó
                return Redirect(Request.Headers["Referer"].ToString());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // giảm số lượng sp
        public async Task<IActionResult> Decrease(string id)
        {
            List<ShopCart> item = HttpContext.Session.GetJson<List<ShopCart>>("Cart") ?? new List<ShopCart>();

            ShopCart cart = item.Where(p => p.Id == id).FirstOrDefault();

            // nếu số lượng sp > 1 thì số lượng sp giảm 1
            if(cart.Quantity > 1)
            {
                --cart.Quantity;
            }

            // nếu số lượng < 1 --> xóa khỏi giỏ hàng
            else
            {
                item.RemoveAll(p => p.Id == id);
            }

            // nếu giỏ hàng trống --> loại bỏ session giỏ hàng
            if(item.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }

            // Nếu có sản phẩm bị xóa hoặc số lượng sản phẩm bị giảm, danh sách giỏ hàng sẽ được cập nhật.
            else
            {
                HttpContext.Session.SetJson("Cart", item);
            }

            return RedirectToAction("Index");
        }

        // tăng số lượng sp
        public async Task<IActionResult> Increase(string id)
        {
            List<ShopCart> item = HttpContext.Session.GetJson<List<ShopCart>>("Cart") ?? new List<ShopCart>();

            ShopCart cart = item.Where(p => p.Id == id).FirstOrDefault();

            if (cart.Quantity >= 1)
            {
                cart.Quantity++;
            }

            HttpContext.Session.SetJson("Cart", item);
            return RedirectToAction("Index");
        }

        // Remove
        public async Task<IActionResult> Remove(string id)
        {
            List<ShopCart> item = HttpContext.Session.GetJson<List<ShopCart>>("Cart") ?? new List<ShopCart>();

            ShopCart cart = item.Where(p => p.Id == id).FirstOrDefault();

            item.RemoveAll(p => p.Id == id);

            HttpContext.Session.SetJson("Cart", item);
            return RedirectToAction("Index");
        }
    }
}
