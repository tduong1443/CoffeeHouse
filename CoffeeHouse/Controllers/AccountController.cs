using CoffeeHouse.Data;
using CoffeeHouse.Migrations;
using CoffeeHouse.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

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
            if(HttpContext.Session.GetString("Username") == null)
            {
                return View();
            }
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
                var u = context.Users.Where(x=>x.Username.Equals(user.Username)
                && x.Password.Equals(user.Password)).FirstOrDefault();
                if (u != null)
                {
                    if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
                    {
                        ModelState.AddModelError("Username", "Enter Username");
                        return View();
                    }
                    HttpContext.Session.SetString("Username", u.Username.ToString());
                    HttpContext.Session.SetString("Role", u.Role);
                    if(u.Role == "Admin")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    if (u.Role == "Customer")
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
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
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("Username");
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
                // Kiểm tra xem tài khoản đã tồn tại chưa
                var existingUser = context.Users.FirstOrDefault(u => u.Username == model.Username);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Username", "This username is already in use.");
                    return View(model);
                }

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

                return RedirectToAction("Login");
            }

            return View(model);
        }
    }
}
