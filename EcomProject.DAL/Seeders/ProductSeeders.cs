// EcomProject.DAL/Seeders/ProductSeeder.cs
using EcomProject.DAL.Models;
using System;
using System.Collections.Generic;

namespace EcomProject.DAL.Seeders
{
    public static class ProductSeeder
    {
        public static (List<Product> Products, List<Category> Categories) SeedData()
        {
            // Hardcoded GUIDs for categories
            var electronicsId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var furnitureId = Guid.Parse("22222222-2222-2222-2222-222222222222");
            var homeAutomationId = Guid.Parse("33333333-3333-3333-3333-333333333333");
            var kitchenwareId = Guid.Parse("44444444-4444-4444-4444-444444444444");
            var fitnessId = Guid.Parse("55555555-5555-5555-5555-555555555555");
            var audioId = Guid.Parse("66666666-6666-6666-6666-666666666666");
            var appliancesId = Guid.Parse("77777777-7777-7777-7777-777777777777");
            var lightingId = Guid.Parse("88888888-8888-8888-8888-888888888888");
            var bagsLuggageId = Guid.Parse("99999999-9999-9999-9999-999999999999");
            var computerAccessoriesId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");

            // Hardcoded GUIDs for products
            var product1Id = Guid.Parse("b1111111-1111-1111-1111-111111111111");
            var product2Id = Guid.Parse("b2222222-2222-2222-2222-222222222222");
            var product3Id = Guid.Parse("b3333333-3333-3333-3333-333333333333");
            var product4Id = Guid.Parse("b4444444-4444-4444-4444-444444444444");
            var product5Id = Guid.Parse("b5555555-5555-5555-5555-555555555555");
            var product6Id = Guid.Parse("b6666666-6666-6666-6666-666666666666");
            var product7Id = Guid.Parse("b7777777-7777-7777-7777-777777777777");
            var product8Id = Guid.Parse("b8888888-8888-8888-8888-888888888888");
            var product9Id = Guid.Parse("b9999999-9999-9999-9999-999999999999");
            var product10Id = Guid.Parse("baaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");

            var categories = new List<Category>
            {
                new Category { CategoryId = electronicsId, Name = "Electronics", Description = "Devices and gadgets for everyday use." },
                new Category { CategoryId = furnitureId, Name = "Furniture", Description = "Comfortable and stylish furniture for home and office." },
                new Category { CategoryId = homeAutomationId, Name = "Home Automation", Description = "Smart devices for home management." },
                new Category { CategoryId = kitchenwareId, Name = "Kitchenware", Description = "High-quality kitchen and dining products." },
                new Category { CategoryId = fitnessId, Name = "Fitness", Description = "Equipment and accessories for fitness enthusiasts." },
                new Category { CategoryId = audioId, Name = "Audio", Description = "High-quality audio devices for music lovers." },
                new Category { CategoryId = appliancesId, Name = "Appliances", Description = "Essential home appliances for daily use." },
                new Category { CategoryId = lightingId, Name = "Lighting", Description = "Modern lighting solutions for home and office." },
                new Category { CategoryId = bagsLuggageId, Name = "Bags & Luggage", Description = "Durable and stylish bags for travel and daily use." },
                new Category { CategoryId = computerAccessoriesId, Name = "Computer Accessories", Description = "Accessories to enhance your computing experience." }
            };

            var products = new List<Product>
            {
                new Product
                {
                    ProductId = product1Id,
                    Name = "Wireless Headphones",
                    Description = "Noise-cancelling wireless headphones with 20-hour battery life.",
                    ManufactureDate = new DateOnly(2023, 1, 15),
                    Price = 199.99m,
                    Discount = 10,
                    CategoryId = electronicsId
                },
                new Product
                {
                    ProductId = product2Id,
                    Name = "Leather Office Chair",
                    Description = "Ergonomic leather chair for office use.",
                    ManufactureDate = new DateOnly(2022, 11, 20),
                    Price = 299.99m,
                    Discount = 15,
                    CategoryId = furnitureId
                },
                new Product
                {
                    ProductId = product3Id,
                    Name = "Smart Thermostat",
                    Description = "Wi-Fi enabled thermostat for energy-efficient heating.",
                    ManufactureDate = new DateOnly(2023, 3, 5),
                    Price = 149.99m,
                    Discount = 5,
                    CategoryId = homeAutomationId
                },
                new Product
                {
                    ProductId = product4Id,
                    Name = "Stainless Steel Water Bottle",
                    Description = "Insulated stainless steel water bottle, 1L capacity.",
                    ManufactureDate = new DateOnly(2023, 2, 10),
                    Price = 24.99m,
                    Discount = 0,
                    CategoryId = kitchenwareId
                },
                new Product
                {
                    ProductId = product5Id,
                    Name = "Yoga Mat",
                    Description = "Eco-friendly yoga mat with non-slip surface.",
                    ManufactureDate = new DateOnly(2023, 4, 1),
                    Price = 39.99m,
                    Discount = 20,
                    CategoryId = fitnessId
                },
                new Product
                {
                    ProductId = product6Id,
                    Name = "Bluetooth Speaker",
                    Description = "Portable Bluetooth speaker with 12-hour battery life.",
                    ManufactureDate = new DateOnly(2023, 1, 25),
                    Price = 79.99m,
                    Discount = 10,
                    CategoryId = audioId
                },
                new Product
                {
                    ProductId = product7Id,
                    Name = "Electric Kettle",
                    Description = "Fast-boiling electric kettle with auto-shutoff.",
                    ManufactureDate = new DateOnly(2023, 3, 15),
                    Price = 49.99m,
                    Discount = 0,
                    CategoryId = appliancesId
                },
                new Product
                {
                    ProductId = product8Id,
                    Name = "LED Desk Lamp",
                    Description = "Adjustable LED desk lamp with 3 brightness levels.",
                    ManufactureDate = new DateOnly(2023, 2, 28),
                    Price = 34.99m,
                    Discount = 5,
                    CategoryId = lightingId
                },
                new Product
                {
                    ProductId = product9Id,
                    Name = "Backpack",
                    Description = "Water-resistant backpack with multiple compartments.",
                    ManufactureDate = new DateOnly(2023, 4, 10),
                    Price = 59.99m,
                    Discount = 15,
                    CategoryId = bagsLuggageId
                },
                new Product
                {
                    ProductId = product10Id,
                    Name = "Wireless Mouse",
                    Description = "Ergonomic wireless mouse with silent clicks.",
                    ManufactureDate = new DateOnly(2023, 3, 20),
                    Price = 29.99m,
                    Discount = 0,
                    CategoryId = computerAccessoriesId
                }
            };

            return (products, categories);
        }
    }
}