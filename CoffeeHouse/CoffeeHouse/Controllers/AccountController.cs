using CoffeeHouse.Data;
using CoffeeHouse.Migrations;
using CoffeeHouse.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace CoffeeHouse.Controllers
{
    public class AccountController : Controller
    {
        private CoffeeHouseContext context;
        public AccountController(CoffeeHouseContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            // Kiểm tra đăng nhập bằng session có tên Username
            // Nếu session Username = null --> người dùng chưa đăng nhập --> Trả về trang đăng nhập
            if(HttpContext.Session.GetString("Username") == null)
            {
                return View();
            }
            // Ngược lại --> người dùng đã đăng nhập rồi --> Trả về trang Home
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Login user)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                // truy vấn csdl tìm username và password nếu tìm được bản ghi phù hợp sẽ được lưu 
                // vào biến u
                var u = context.Users.Where(x=>x.Username.Equals(user.Username)
                && x.Password.Equals(user.Password)).FirstOrDefault();

                // Kiểm tra xem u có null hay không 
                if (u != null)
                {
                    if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
                    {
                        ModelState.AddModelError("Username", "Enter Username");
                        return View();
                    }
                    // lưu Username của người dùng vào u
                    HttpContext.Session.SetString("Username", u.Username.ToString());
                    // lưu quyề của người dùng vào u
                    HttpContext.Session.SetString("Role", u.Role);
                    // nếu người dùng có phân quyền admin --> truy cập trang admin
                    if(u.Role == "Admin")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    // nếu người dùng có phân quyền customer --> truy cập trang chính
                    if (u.Role == "Customer")
                    {
                        HttpContext.Session.SetString("IsLoggedIn", "true");
                        return RedirectToAction("Index", "Home");
                    }
                }
                // nếu u null sẽ báo lỗi
                else
                {
                    ModelState.AddModelError("Username", "Invalid Username or Password");
                    return View(user);
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            // xóa toàn bộ dữ liệu trong phiên làm việc của người dùng
            HttpContext.Session.Clear();
            // xóa username
            HttpContext.Session.Remove("Username");
            // trả về trang chủ
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Join()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Join(Register model)
        {
            if (ModelState.IsValid)
            {
                if (!IsValidEmail(model.Email))
                {
                    ModelState.AddModelError("Email", "The email address is not in a valid format.");
                    return View(model);
                }

                // Validate password format (example: at least 8 characters)
                if (!IsValidPassword(model.Password))
                {
                    ModelState.AddModelError("Password", "The password must be 8 to 25 characters long that includes at least 1 uppercase and 1 lowercase letter, 1 number and 1 special character.");
                    return View(model);
                }

                // Kiểm tra xem tài khoản đã tồn tại chưa
                var existingUser = context.Users.FirstOrDefault(u => u.Username == model.Username);
                // nếu đã tồn tại --> báo lỗi
                if (existingUser != null)
                {
                    ModelState.AddModelError("Username", "This username is already in use.");
                    return View(model);
                }

                // nếu chưa tồn tại
                // Tạo một đối tượng User và lưu vào cơ sở dữ liệu
                var user = new Users
                {
                    Username = model.Username,
                    Password = model.Password,
                    Email = model.Email,
                    Role = "Customer"
                };
                context.Users.Add(user);
                context.SaveChanges();

                // đăng kí thành công trả về trang login
                return RedirectToAction("Login");
            }

            return View(model);
        }

        private bool IsValidEmail(string email)
        {
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return emailRegex.IsMatch(email);
        }

        // Helper method to validate password format (example: at least 8 characters)
        private bool IsValidPassword(string password)
        {
            var passwordRegex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^A-Za-z0-9]).{8,25}$");
            return passwordRegex.IsMatch(password);
        }
    }
}
