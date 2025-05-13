using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcomProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class v03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("07e421b0-ce02-4543-a008-45a275d303a6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("5633d857-3300-44bb-b533-25d8b404a825"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("1bec30a4-54e8-493e-a042-0b083883150d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("a97400ef-97da-421f-8274-2ee372619e46"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Electronic items", "Electronics" },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "Various kinds of books", "Books" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Discount", "ManufactureDate", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Latest model smartphone", 10, new DateOnly(2023, 10, 10), "Smartphone", 799.99m },
                    { new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "Bestselling fantasy novel", 5, new DateOnly(2022, 5, 15), "Fantasy Novel", 29.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("1bec30a4-54e8-493e-a042-0b083883150d"), "Electronic items", "Electronics" },
                    { new Guid("a97400ef-97da-421f-8274-2ee372619e46"), "Various kinds of books", "Books" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Discount", "ManufactureDate", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("07e421b0-ce02-4543-a008-45a275d303a6"), new Guid("1bec30a4-54e8-493e-a042-0b083883150d"), "Latest model smartphone", 10, new DateOnly(2023, 10, 10), "Smartphone", 799.99m },
                    { new Guid("5633d857-3300-44bb-b533-25d8b404a825"), new Guid("a97400ef-97da-421f-8274-2ee372619e46"), "Bestselling fantasy novel", 5, new DateOnly(2022, 5, 15), "Fantasy Novel", 29.99m }
                });
        }
    }
}
