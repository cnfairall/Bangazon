using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bangazon.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    Open = table.Column<bool>(type: "boolean", nullable: false),
                    DatePlaced = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PaymentTypeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    SellerId = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    QuantityAvail = table.Column<int>(type: "integer", nullable: false),
                    PricePer = table.Column<decimal>(type: "numeric", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Uid = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    IsSeller = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "integer", nullable: false),
                    ProductsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.OrdersId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_OrderProduct_Order_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sporting Goods" },
                    { 2, "Clothing" },
                    { 3, "Dry Goods" },
                    { 4, "Books" },
                    { 5, "Automotive" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "CustomerId", "DatePlaced", "Open", "PaymentTypeId" },
                values: new object[,]
                {
                    { 1, 2, null, true, null },
                    { 2, 3, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1 },
                    { 3, 1, new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2 },
                    { 4, 3, null, true, null }
                });

            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Debit Card" },
                    { 2, "Credit Card" },
                    { 3, "PayPal" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateAdded", "Description", "ImageUrl", "PricePer", "QuantityAvail", "SellerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Always comes back!", "https://tse1.mm.bing.net/th?id=OIP.HFDa4OD0-IeYTX5t5CB1FgHaGq&pid=Api&P=0&h=220", 12.00m, 15, 1, "Bone Boomerang" },
                    { 2, 2, new DateTime(2024, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Not cursed!", "https://sp.yimg.com/ib/th?id=OPHS.0VTDiWr0%2fU%2fVFw474C474&o=5&pid=21.1&w=160&h=105", 120.00m, 1, 2, "Wedding gown" },
                    { 3, 3, new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Everything you need", "https://sp.yimg.com/ib/th?id=OPHS.BHEw0gGLElfx9A474C474&o=5&pid=21.1&w=160&h=105", 60.00m, 6, 1, "Prepper Bucket" },
                    { 4, 4, new DateTime(2023, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "very long", "https://tse2.mm.bing.net/th?id=OIP.UlJzwVqHm_CbLNAdaKcKNAHaLH&pid=Api&P=0&h=220", 8.00m, 2, 2, "The Memoir Book" },
                    { 5, 2, new DateTime(2024, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nashville classic", "https://tse2.mm.bing.net/th?id=OIP.UlJzwVqHm_CbLNAdaKcKNAHaLH&pid=Api&P=0&h=220", 12.00m, 20, 2, "Cowgirl Hat" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FirstName", "ImageUrl", "IsSeller", "LastName", "Uid", "Username" },
                values: new object[,]
                {
                    { 1, "24 Hollyhock Ln, Atlanta, GA 13024", "fastcar@yahoo.com", "Larry", "https://up.yimg.com/ib/th?id=OIP.IcMrOf627VHm5umBg-NdkQHaMC&%3Bpid=Api&rs=1&c=1&qlt=95&w=76&h=123", true, "Dingle", "Z487K28", "fastestCar" },
                    { 2, "1824A Cypress Circle, Detroit, MI 57351", "nightmoves81@gmail.com", "Denise", "https://tse2.mm.bing.net/th?id=OIP.roc7SqiVeXDbnAinXSVdTQHaNK&pid=Api&P=0&h=220", false, "Arriat", "FQ985B8", "NightMoves81" },
                    { 3, "7 Moonlight Way, Miami, FL 92118", "lilyrose@yahoo.com", "Sheryl", "https://tse2.mm.bing.net/th?id=OIP.vahulDgxNXU-mGHiUzFbLwHaLH&pid=Api&P=0&h=220", true, "Barnes", "Z487K28", "LilyRose3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductsId",
                table: "OrderProduct",
                column: "ProductsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
