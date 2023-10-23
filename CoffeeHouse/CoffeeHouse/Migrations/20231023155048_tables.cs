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
                    IdCustomer = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    IdSatff = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.IdSatff);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    IdProduct = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdCategory = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
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
                    IdStaff = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdCustomer = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                        principalColumn: "IdSatff",
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
                    { "C01", "Capuchino" },
                    { "C02", "Cafe" },
                    { "C03", "Latte" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "IdCustomer", "Address", "Birthday", "Email", "FullName", "Phone" },
                values: new object[,]
                {
                    { "Cs01", "Ha Noi", new DateTime(2003, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "tuyen@gmail.com", "Nguyen Van Tuyen", "0111444666" },
                    { "Cs02", "Thai Binh", new DateTime(2003, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "quang@gmail.com", "Pham Huu Quang", "0111444777" }
                });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "IdSatff", "Address", "Birthday", "Email", "FullName", "Phone", "Position" },
                values: new object[,]
                {
                    { "S01", "Thai Binh", new DateTime(2003, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "duong@gmail.com", "Nguyen Thuy Duong", "0111333444", "Manager" },
                    { "S02", "Ha Noi", new DateTime(2003, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "hduong@gmail.com", "Hoang Duong", "0222444555", "Staff" },
                    { "S03", "Quang Ninh", new DateTime(2003, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "phu@gmail.com", "Nguyen Gia Phu", "0111322666", "Staff" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "IdOrders", "IdCustomer", "IdStaff", "Note", "OrderDate" },
                values: new object[,]
                {
                    { "Or01", "Cs01", "S03", "Đã thanh toán", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Or02", "Cs02", "S01", "Chưa thanh toán", new DateTime(2023, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Or03", "Cs02", "S02", "Đã thanh toán", new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Or04", "Cs01", "S01", "Đã thanh toán", new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "IdProduct", "IdCategory", "Name", "Price" },
                values: new object[,]
                {
                    { "P01", "C02", "Cafe Latte", 50.25f },
                    { "P02", "C01", "Capuchino Vinnese", 50.25f },
                    { "P03", "C03", "Latte Machiato", 50.25f },
                    { "P04", "C01", "Capuchino", 50.25f },
                    { "P05", "C02", "Cafe Mocha", 50.25f }
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
