﻿namespace EcomProject.DAL.Models
{
    public class BasketItem
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }
        public int Quantity { get; set; }

        public decimal Price { get; set; } 

        public string Category { get; set; }
    }
}