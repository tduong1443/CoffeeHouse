using CoffeeHouse.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace CoffeeHouse.Data
{
    public class CoffeeHouseContext : DbContext
    {
       
        public CoffeeHouseContext(DbContextOptions<CoffeeHouseContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderInfo> OrdersInfo { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Menu> Menu { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { IdCategory = "C01", Name = "Capuchino Coffee" },
                new Category { IdCategory = "C02", Name = "CoffeeBag" },
                new Category { IdCategory = "C03", Name = "Arabica Roasted" },
                new Category { IdCategory = "C04", Name = "Arabica Green" },
                new Category { IdCategory = "C05", Name = "Cold Brewed" },
                new Category { IdCategory = "C06", Name = "Robusta Roasted" },
                new Category { IdCategory = "C07", Name = "Uncategorized" }
            );

            modelBuilder.Entity<Products>().HasData(
                new Products { IdProduct = "P01", IdCategory = "C05", Name = "Lost Planes", Price = 50.25f, Image = "~/images_icon/menu/list_menu/01.png" },
                new Products { IdProduct = "P02", IdCategory = "C01", Name = "Saint Helena", Price = 50.25f, Image = "~/images_icon/menu/list_menu/02.png" },
                new Products { IdProduct = "P03", IdCategory = "C03", Name = "Kona Peaberry", Price = 50.25f, Image = "~/images_icon/menu/list_menu/03.png" },
                new Products { IdProduct = "P04", IdCategory = "C04", Name = "Blue Mountain", Price = 50.25f, Image = "~/images_icon/menu/list_menu/04.png" },
                new Products { IdProduct = "P05", IdCategory = "C07", Name = "Ospina", Price = 50.25f, Image = "~/images_icon/menu/list_menu/05.png" },
                new Products { IdProduct = "P06", IdCategory = "C02", Name = "Kupi Luwak", Price = 50.25f, Image = "~/images_icon/menu/list_menu/06.png" },
                new Products { IdProduct = "P07", IdCategory = "C01", Name = "Capuchino Coffee", Price = 50.25f, Image = "~/images_icon/menu/list_menu/07.png" },
                new Products { IdProduct = "P08", IdCategory = "C06", Name = "Balck Ivory", Price = 50.25f, Image = "~/images_icon/menu/list_menu/08.png" },
                new Products { IdProduct = "P09", IdCategory = "C02", Name = "Americano Coffee", Price = 50.25f, Image = "~/images_icon/menu/list_menu/09.png" }
            );

            modelBuilder.Entity<Menu>().HasData(
                new Menu { Id = "P01", IdCategory = "C05", Name = "Espresso", Price = 50.25f, Image = "~/images_icon/menu/list_menu/mn1.jpg" },
                new Menu { Id = "P02", IdCategory = "C02", Name = "Latte Macchiato", Price = 50.25f, Image = "~/images_icon/menu/list_menu/mn2.jpg" },
                new Menu { Id = "P03", IdCategory = "C01", Name = "Capuchino", Price = 50.25f, Image = "~/images_icon/menu/list_menu/mn3.jpg" },
                new Menu { Id = "P04", IdCategory = "C04", Name = "Coffee Latte", Price = 50.25f, Image = "~/images_icon/menu/list_menu/mn4.jpg" },
                new Menu { Id = "P05", IdCategory = "C07", Name = "Coffee Mocha", Price = 50.25f, Image = "~/images_icon/menu/list_menu/mn5.jpg" },
                new Menu { Id = "P06", IdCategory = "C02", Name = "Americano", Price = 50.25f, Image = "~/images_icon/menu/list_menu/mn6.jpg" },
                new Menu { Id = "P07", IdCategory = "C06", Name = "Espresso Con Panna", Price = 50.25f, Image = "~/images_icon/menu/list_menu/mn7.jpg" },
                new Menu { Id = "P08", IdCategory = "C01", Name = "Capuchino Viennese", Price = 50.25f, Image = "~/images_icon/menu/list_menu/mn8.jpg" }
            );

            modelBuilder.Entity<Staff>().HasData(
                new Staff { IdStaff = 1, FullName = "Nguyen Thuy Duong", Birthday = DateTime.Parse("2003-4-14"), Email = "duong@gmail.com", Phone = "0111333444", Address = "Thai Binh", Position = "Manager"},
                new Staff { IdStaff = 2, FullName = "Hoang Duong", Birthday = DateTime.Parse("2003-10-18"), Email = "hduong@gmail.com", Phone = "0222444555", Address = "Ha Noi", Position = "Staff"},
                new Staff { IdStaff = 3, FullName = "Nguyen Gia Phu", Birthday = DateTime.Parse("2003-12-30"), Email = "phu@gmail.com", Phone = "0111322666", Address = "Quang Ninh", Position = "Staff"}
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { IdCustomer= 1, Fullname = "Nguyen Van Tuyen", Email = "tuyen@gmail.com",Birthday = DateTime.Parse("2003-1-1"), Address = "Ha Noi", Phone = "112233556677"},
                new Customer { IdCustomer= 2, Fullname = "Pham Huu Quang", Email = "quang@gmail.com", Birthday = DateTime.Parse("2003-2-2"), Address = "Thai Binh", Phone = "00044455588"}
            );

            modelBuilder.Entity<OrderInfo>().HasData(
                new OrderInfo { Id = 1, IdOrders = "Or01", IdProduct = "P01", Number = 2, Reduce = 0.0f },
                new OrderInfo { Id = 2, IdOrders = "Or02", IdProduct = "P02", Number = 1, Reduce = 0.0f },
                new OrderInfo { Id = 3, IdOrders = "Or03", IdProduct = "P05", Number = 3, Reduce = 0.0f },
                new OrderInfo { Id = 4, IdOrders = "Or04", IdProduct = "P04", Number = 1, Reduce = 0.0f }
            );

            modelBuilder.Entity<Orders>().HasData(
                new Orders { IdOrders = "Or01", IdCustomer= 1, IdStaff = 3, OrderDate = DateTime.Parse("2023-1-1"), Note = "Đã thanh toán" },
                new Orders { IdOrders = "Or02", IdCustomer= 2, IdStaff = 1, OrderDate = DateTime.Parse("2023-11-11"), Note = "Chưa thanh toán" },
                new Orders { IdOrders = "Or03", IdCustomer= 2, IdStaff = 2, OrderDate = DateTime.Parse("2023-2-2"), Note = "Đã thanh toán" },
                new Orders { IdOrders = "Or04", IdCustomer= 1, IdStaff = 1, OrderDate = DateTime.Parse("2023-4-4"), Note = "Đã thanh toán" }
            );

            modelBuilder.Entity<Users>().HasData(
                new Users { Username = "duongnt", Password = "Duong@123", Email = "duong@gmail.com", Role = "Admin"},
                new Users { Username = "duongh", Password = "Hduong@123", Email = "hduong@gmail.com", Role = "Admin"},
                new Users { Username = "phung", Password = "Phu@1234", Email = "phu@gmail.com", Role = "Admin"},
                new Users { Username = "tuyennv", Password = "Tuyen@123", Email = "tuyen@gmail.com", Role = "Customer"},
                new Users { Username = "quangph", Password = "Quang@123", Email = "quang@gmail.com", Role = "Customer"}
            );
        }
    }
}
