using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Carrito.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dni = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VIP = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartProducts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProducts", x => new { x.CartId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CartProducts_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Smartphone con pantalla de 6.5' y cámara de 48MP", "Smartphone", 799m },
                    { 2, "Laptop con procesador i7, 16GB de RAM y 512GB SSD", "Laptop", 1200m },
                    { 3, "Auriculares inalámbricos con cancelación de ruido", "Auriculares Bluetooth", 150m },
                    { 4, "Televisor de 55' con resolución 4K y Smart TV", "Televisor 4K", 800m },
                    { 5, "Cargador inalámbrico rápido para dispositivos compatibles", "Cargador Inalámbrico", 50m },
                    { 6, "Tablet de 10' con 64GB de almacenamiento y 4GB de RAM", "Tablet", 350m },
                    { 7, "Reloj inteligente con monitor de frecuencia cardíaca y GPS", "Smartwatch", 220m },
                    { 8, "Cámara digital de 20MP con pantalla táctil y Wi-Fi integrado", "Cámara Digital", 450m },
                    { 9, "Parlantes inalámbricos con sonido estéreo y batería de larga duración", "Parlantes Bluetooth", 120m },
                    { 10, "Auriculares con micrófono y sonido envolvente para juegos", "Auriculares Gaming", 90m },
                    { 11, "Drone con cámara 4K y control remoto de 100m", "Drone", 350m },
                    { 12, "Reproductor de Blu-ray con acceso a streaming y 4K", "Reproductor de Blu-ray", 120m },
                    { 13, "Disco duro externo de 1TB con USB 3.0 para transferencias rápidas", "Disco Duro Externo", 80m },
                    { 14, "Monitor 27' 4K con resolución Ultra HD y tecnología IPS", "Monitor 4K", 350m },
                    { 15, "Teclado mecánico con retroiluminación RGB y teclas programables", "Teclado Mecánico", 110m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_ProductId",
                table: "CartProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartProducts");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
