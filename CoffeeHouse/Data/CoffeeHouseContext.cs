using CoffeeHouse.Models;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { IdCategory = "C01", Name = "Capuchino" },
                new Category { IdCategory = "C02", Name = "Cafe" },
                new Category { IdCategory = "C03", Name = "Latte" }
            );

            modelBuilder.Entity<Products>().HasData(
                new Products { IdProduct = "P01", IdCategory = "C02", Name = "Cafe Latte", Price = 50.25f },
                new Products { IdProduct = "P02", IdCategory = "C01", Name = "Capuchino Vinnese", Price = 50.25f },
                new Products { IdProduct = "P03", IdCategory = "C03", Name = "Latte Machiato", Price = 50.25f },
                new Products { IdProduct = "P04", IdCategory = "C01", Name = "Capuchino", Price = 50.25f },
                new Products { IdProduct = "P05", IdCategory = "C02", Name = "Cafe Mocha", Price = 50.25f }
            );

            modelBuilder.Entity<Staff>().HasData(
                new Staff { IdSatff = "S01", FullName = "Nguyen Thuy Duong", Birthday = DateTime.Parse("2003-4-14"), Email = "duong@gmail.com", Phone = "0111333444", Address = "Thai Binh", Position = "Manager" },
                new Staff { IdSatff = "S02", FullName = "Hoang Duong", Birthday = DateTime.Parse("2003-10-18"), Email = "hduong@gmail.com", Phone = "0222444555", Address = "Ha Noi", Position = "Staff" },
                new Staff { IdSatff = "S03", FullName = "Nguyen Gia Phu", Birthday = DateTime.Parse("2003-12-30"), Email = "phu@gmail.com", Phone = "0111322666", Address = "Quang Ninh", Position = "Staff" }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { IdCustomer= "Cs01", FullName = "Nguyen Van Tuyen", Birthday = DateTime.Parse("2003-1-1"), Email = "tuyen@gmail.com", Phone = "0111444666", Address = "Ha Noi" },
                new Customer { IdCustomer= "Cs02", FullName = "Pham Huu Quang", Birthday = DateTime.Parse("2003-11-1"), Email = "quang@gmail.com", Phone = "0111444777", Address = "Thai Binh" }
            );

            modelBuilder.Entity<OrderInfo>().HasData(
                new OrderInfo { Id = 1, IdOrders = "Or01", IdProduct = "P01", Number = 2, Reduce = 0.0f },
                new OrderInfo { Id = 2, IdOrders = "Or02", IdProduct = "P02", Number = 1, Reduce = 0.0f },
                new OrderInfo { Id = 3, IdOrders = "Or03", IdProduct = "P05", Number = 3, Reduce = 0.0f },
                new OrderInfo { Id = 4, IdOrders = "Or04", IdProduct = "P04", Number = 1, Reduce = 0.0f }
            );

            modelBuilder.Entity<Orders>().HasData(
                new Orders { IdOrders = "Or01", IdCustomer= "Cs01", IdStaff = "S03", OrderDate = DateTime.Parse("2023-1-1"), Note = "Đã thanh toán" },
                new Orders { IdOrders = "Or02", IdCustomer= "Cs02", IdStaff = "S01", OrderDate = DateTime.Parse("2023-11-11"), Note = "Chưa thanh toán" },
                new Orders { IdOrders = "Or03", IdCustomer= "Cs02", IdStaff = "S02", OrderDate = DateTime.Parse("2023-2-2"), Note = "Đã thanh toán" },
                new Orders { IdOrders = "Or04", IdCustomer= "Cs01", IdStaff = "S01", OrderDate = DateTime.Parse("2023-4-4"), Note = "Đã thanh toán" }
            );
        }
    }
}
