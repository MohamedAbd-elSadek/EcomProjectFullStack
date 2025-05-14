using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcomProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class seedingProductsANDCategories2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("18ab1b16-fb91-48eb-b3cc-c6ca78ca27c1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("2ffd6f27-ec2f-4c5c-bb6d-3696dbfc19b1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("30cd4e3e-713d-49c4-bfd6-0b9a3397d6a2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("37889d2a-9036-4f2b-9f43-dbc081587c22"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("69b98343-bccb-43c7-a81f-d21a506995f5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("76bdcd16-a467-4a43-be54-60a682f9f097"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("7ee6f6fb-3c44-4d88-a66c-0805b3a9ff3d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("d8fb6052-f65a-4a7d-b66e-253e7e588919"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("dcdf275f-569b-495d-b31b-1bc7768609a4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("f6cc363d-166e-450e-962c-69f25ae7ee1e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("0bf114eb-4628-4ca7-afe1-34794aec6148"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("3b9ff13b-6710-49f5-93a1-91606740a046"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("56f443af-13db-42de-87dc-32c29af77930"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("681d5e12-a354-44d0-a2db-5e880f41f8bb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("684f4d29-2a41-405f-b45b-eccda68c6eb2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("760b3280-d388-4e1c-bdb8-580f046e9c91"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("7a79204f-3df3-448f-99e8-a51bf60178ac"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("8192919e-a763-4fd1-bb30-bea06339e904"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("84219a8e-dd9a-4df6-9234-cac995fd8c4e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("cbfa6f78-6ffa-457f-ac6e-d688005aeab4"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Devices and gadgets for everyday use.", "Electronics" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Comfortable and stylish furniture for home and office.", "Furniture" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Smart devices for home management.", "Home Automation" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "High-quality kitchen and dining products.", "Kitchenware" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "Equipment and accessories for fitness enthusiasts.", "Fitness" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), "High-quality audio devices for music lovers.", "Audio" },
                    { new Guid("77777777-7777-7777-7777-777777777777"), "Essential home appliances for daily use.", "Appliances" },
                    { new Guid("88888888-8888-8888-8888-888888888888"), "Modern lighting solutions for home and office.", "Lighting" },
                    { new Guid("99999999-9999-9999-9999-999999999999"), "Durable and stylish bags for travel and daily use.", "Bags & Luggage" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Accessories to enhance your computing experience.", "Computer Accessories" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Discount", "ManufactureDate", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("b1111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "Noise-cancelling wireless headphones with 20-hour battery life.", 10, new DateOnly(2023, 1, 15), "Wireless Headphones", 199.99m },
                    { new Guid("b2222222-2222-2222-2222-222222222222"), new Guid("22222222-2222-2222-2222-222222222222"), "Ergonomic leather chair for office use.", 15, new DateOnly(2022, 11, 20), "Leather Office Chair", 299.99m },
                    { new Guid("b3333333-3333-3333-3333-333333333333"), new Guid("33333333-3333-3333-3333-333333333333"), "Wi-Fi enabled thermostat for energy-efficient heating.", 5, new DateOnly(2023, 3, 5), "Smart Thermostat", 149.99m },
                    { new Guid("b4444444-4444-4444-4444-444444444444"), new Guid("44444444-4444-4444-4444-444444444444"), "Insulated stainless steel water bottle, 1L capacity.", 0, new DateOnly(2023, 2, 10), "Stainless Steel Water Bottle", 24.99m },
                    { new Guid("b5555555-5555-5555-5555-555555555555"), new Guid("55555555-5555-5555-5555-555555555555"), "Eco-friendly yoga mat with non-slip surface.", 20, new DateOnly(2023, 4, 1), "Yoga Mat", 39.99m },
                    { new Guid("b6666666-6666-6666-6666-666666666666"), new Guid("66666666-6666-6666-6666-666666666666"), "Portable Bluetooth speaker with 12-hour battery life.", 10, new DateOnly(2023, 1, 25), "Bluetooth Speaker", 79.99m },
                    { new Guid("b7777777-7777-7777-7777-777777777777"), new Guid("77777777-7777-7777-7777-777777777777"), "Fast-boiling electric kettle with auto-shutoff.", 0, new DateOnly(2023, 3, 15), "Electric Kettle", 49.99m },
                    { new Guid("b8888888-8888-8888-8888-888888888888"), new Guid("88888888-8888-8888-8888-888888888888"), "Adjustable LED desk lamp with 3 brightness levels.", 5, new DateOnly(2023, 2, 28), "LED Desk Lamp", 34.99m },
                    { new Guid("b9999999-9999-9999-9999-999999999999"), new Guid("99999999-9999-9999-9999-999999999999"), "Water-resistant backpack with multiple compartments.", 15, new DateOnly(2023, 4, 10), "Backpack", 59.99m },
                    { new Guid("baaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Ergonomic wireless mouse with silent clicks.", 0, new DateOnly(2023, 3, 20), "Wireless Mouse", 29.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("b1111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("b2222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("b3333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("b4444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("b5555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("b6666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("b7777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("b8888888-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("b9999999-9999-9999-9999-999999999999"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("baaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("0bf114eb-4628-4ca7-afe1-34794aec6148"), "High-quality kitchen and dining products.", "Kitchenware" },
                    { new Guid("3b9ff13b-6710-49f5-93a1-91606740a046"), "Devices and gadgets for everyday use.", "Electronics" },
                    { new Guid("56f443af-13db-42de-87dc-32c29af77930"), "Essential home appliances for daily use.", "Appliances" },
                    { new Guid("681d5e12-a354-44d0-a2db-5e880f41f8bb"), "Smart devices for home management.", "Home Automation" },
                    { new Guid("684f4d29-2a41-405f-b45b-eccda68c6eb2"), "Comfortable and stylish furniture for home and office.", "Furniture" },
                    { new Guid("760b3280-d388-4e1c-bdb8-580f046e9c91"), "High-quality audio devices for music lovers.", "Audio" },
                    { new Guid("7a79204f-3df3-448f-99e8-a51bf60178ac"), "Modern lighting solutions for home and office.", "Lighting" },
                    { new Guid("8192919e-a763-4fd1-bb30-bea06339e904"), "Durable and stylish bags for travel and daily use.", "Bags & Luggage" },
                    { new Guid("84219a8e-dd9a-4df6-9234-cac995fd8c4e"), "Equipment and accessories for fitness enthusiasts.", "Fitness" },
                    { new Guid("cbfa6f78-6ffa-457f-ac6e-d688005aeab4"), "Accessories to enhance your computing experience.", "Computer Accessories" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Discount", "ManufactureDate", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("18ab1b16-fb91-48eb-b3cc-c6ca78ca27c1"), new Guid("3b9ff13b-6710-49f5-93a1-91606740a046"), "Noise-cancelling wireless headphones with 20-hour battery life.", 10, new DateOnly(2023, 1, 15), "Wireless Headphones", 199.99m },
                    { new Guid("2ffd6f27-ec2f-4c5c-bb6d-3696dbfc19b1"), new Guid("7a79204f-3df3-448f-99e8-a51bf60178ac"), "Adjustable LED desk lamp with 3 brightness levels.", 5, new DateOnly(2023, 2, 28), "LED Desk Lamp", 34.99m },
                    { new Guid("30cd4e3e-713d-49c4-bfd6-0b9a3397d6a2"), new Guid("8192919e-a763-4fd1-bb30-bea06339e904"), "Water-resistant backpack with multiple compartments.", 15, new DateOnly(2023, 4, 10), "Backpack", 59.99m },
                    { new Guid("37889d2a-9036-4f2b-9f43-dbc081587c22"), new Guid("0bf114eb-4628-4ca7-afe1-34794aec6148"), "Insulated stainless steel water bottle, 1L capacity.", 0, new DateOnly(2023, 2, 10), "Stainless Steel Water Bottle", 24.99m },
                    { new Guid("69b98343-bccb-43c7-a81f-d21a506995f5"), new Guid("684f4d29-2a41-405f-b45b-eccda68c6eb2"), "Ergonomic leather chair for office use.", 15, new DateOnly(2022, 11, 20), "Leather Office Chair", 299.99m },
                    { new Guid("76bdcd16-a467-4a43-be54-60a682f9f097"), new Guid("760b3280-d388-4e1c-bdb8-580f046e9c91"), "Portable Bluetooth speaker with 12-hour battery life.", 10, new DateOnly(2023, 1, 25), "Bluetooth Speaker", 79.99m },
                    { new Guid("7ee6f6fb-3c44-4d88-a66c-0805b3a9ff3d"), new Guid("84219a8e-dd9a-4df6-9234-cac995fd8c4e"), "Eco-friendly yoga mat with non-slip surface.", 20, new DateOnly(2023, 4, 1), "Yoga Mat", 39.99m },
                    { new Guid("d8fb6052-f65a-4a7d-b66e-253e7e588919"), new Guid("681d5e12-a354-44d0-a2db-5e880f41f8bb"), "Wi-Fi enabled thermostat for energy-efficient heating.", 5, new DateOnly(2023, 3, 5), "Smart Thermostat", 149.99m },
                    { new Guid("dcdf275f-569b-495d-b31b-1bc7768609a4"), new Guid("56f443af-13db-42de-87dc-32c29af77930"), "Fast-boiling electric kettle with auto-shutoff.", 0, new DateOnly(2023, 3, 15), "Electric Kettle", 49.99m },
                    { new Guid("f6cc363d-166e-450e-962c-69f25ae7ee1e"), new Guid("cbfa6f78-6ffa-457f-ac6e-d688005aeab4"), "Ergonomic wireless mouse with silent clicks.", 0, new DateOnly(2023, 3, 20), "Wireless Mouse", 29.99m }
                });
        }
    }
}
