﻿using CaishenManagementAPI.Enums;

namespace CaishenManagementAPI.Models.DTO
{
    public class ProductDTO
    {           
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public int StockQuantity { get; set; }
        public ProductStatus Status { get; set; } = ProductStatus.Active; 
    }
}
