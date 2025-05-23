﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.BL.DTOs.Product
{
    public class ProductUpdateDTO
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public DateOnly ManufactureDate { get; set; }

        public decimal Price { get; set; }

        public int Discount { get; set; }
        public Guid CategoryId { get; set; }
    }
}
