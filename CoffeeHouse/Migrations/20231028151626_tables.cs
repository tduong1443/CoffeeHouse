using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoffeeHouse.Migrations
{
    /// <inheritdoc />
    public partial class tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    IdCategory = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.IdCategory);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    IdCustomer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.IdCustomer);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    IdStaff = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.IdStaff);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    IdProduct = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdCategory = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.IdProduct);
                    table.ForeignKey(
                        name: "FK_Products_Categories_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "Categories",
                        principalColumn: "IdCategory",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    IdOrders = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdStaff = table.Column<int>(type: "int", nullable: false),
                    IdCustomer = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.IdOrders);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "Customers",
                        principalColumn: "IdCustomer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Staff_IdStaff",
                        column: x => x.IdStaff,
                        principalTable: "Staff",
                        principalColumn: "IdStaff",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdersInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    IdOrders = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdProduct = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Reduce = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdersInfo_Orders_IdOrders",
                        column: x => x.IdOrders,
                        principalTable: "Orders",
                        principalColumn: "IdOrders",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdersInfo_Products_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "Products",
                        principalColumn: "IdProduct",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "IdCategory", "Name" },
                values: new object[,]
                {
                    { "C01", "Capuchino Coffee" },
                    { "C02", "CoffeeBag" },
                    { "C03", "Arabica Roasted" },
                    { "C04", "Arabica Green" },
                    { "C05", "Cold Brewed" },
                    { "C06", "Robusta Roasted" },
                    { "C07", "Uncategorized" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "IdCustomer", "Address", "Birthday", "Email", "Fullname", "Phone" },
                values: new object[,]
                {
                    { 1, "Ha Noi", new DateTime(2003, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "tuyen@gmail.com", "Nguyen Van Tuyen", "112233556677" },
                    { 2, "Thai Binh", new DateTime(2003, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "quang@gmail.com", "Pham Huu Quang", "00044455588" }
                });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "IdStaff", "Address", "Birthday", "Email", "FullName", "Phone", "Position" },
                values: new object[,]
                {
                    { 1, "Thai Binh", new DateTime(2003, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "duong@gmail.com", "Nguyen Thuy Duong", "0111333444", "Manager" },
                    { 2, "Ha Noi", new DateTime(2003, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "hduong@gmail.com", "Hoang Duong", "0222444555", "Staff" },
                    { 3, "Quang Ninh", new DateTime(2003, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "phu@gmail.com", "Nguyen Gia Phu", "0111322666", "Staff" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Username", "Email", "Password", "Role" },
                values: new object[,]
                {
                    { "duongh", "hduong@gmail.com", "Hduong@123", "Admin" },
                    { "duongnt", "duong@gmail.com", "Duong@123", "Admin" },
                    { "phung", "phu@gmail.com", "Phu@1234", "Admin" },
                    { "quangph", "quang@gmail.com", "Quang@123", "Customer" },
                    { "tuyennv", "tuyen@gmail.com", "Tuyen@123", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "IdOrders", "IdCustomer", "IdStaff", "Note", "OrderDate" },
                values: new object[,]
                {
                    { "Or01", 1, 3, "Đã thanh toán", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Or02", 2, 1, "Chưa thanh toán", new DateTime(2023, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Or03", 2, 2, "Đã thanh toán", new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Or04", 1, 1, "Đã thanh toán", new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "IdProduct", "IdCategory", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { "P01", "C05", "~/images_icon/menu/list_menu/01.png", "Lost Planes", 50.25f },
                    { "P02", "C01", "~/images_icon/menu/list_menu/02.png", "Saint Helena", 50.25f },
                    { "P03", "C03", "~/images_icon/menu/list_menu/03.png", "Kona Peaberry", 50.25f },
                    { "P04", "C04", "~/images_icon/menu/list_menu/04.png", "Blue Mountain", 50.25f },
                    { "P05", "C07", "~/images_icon/menu/list_menu/05.png", "Ospina", 50.25f },
                    { "P06", "C02", "~/images_icon/menu/list_menu/06.png", "Kupi Luwak", 50.25f },
                    { "P07", "C01", "~/images_icon/menu/list_menu/07.png", "Capuchino Coffee", 50.25f },
                    { "P08", "C06", "~/images_icon/menu/list_menu/08.png", "Balck Ivory", 50.25f },
                    { "P09", "C02", "~/images_icon/menu/list_menu/09.png", "Americano Coffee", 50.25f }
                });

            migrationBuilder.InsertData(
                table: "OrdersInfo",
                columns: new[] { "Id", "IdOrders", "IdProduct", "Number", "Reduce" },
                values: new object[,]
                {
                    { 1, "Or01", "P01", 2, 0f },
                    { 2, "Or02", "P02", 1, 0f },
                    { 3, "Or03", "P05", 3, 0f },
                    { 4, "Or04", "P04", 1, 0f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdCustomer",
                table: "Orders",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdStaff",
                table: "Orders",
                column: "IdStaff");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersInfo_IdOrders",
                table: "OrdersInfo",
                column: "IdOrders");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersInfo_IdProduct",
                table: "OrdersInfo",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdCategory",
                table: "Products",
                column: "IdCategory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdersInfo");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
