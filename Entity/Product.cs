using CaishenManagementAPI.Enums;

namespace CaishenManagementAPI.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductTypeid { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal ImportPrice { get; set; }
        public decimal SellPrice { get; set; }
        public int StockQuantity { get; set; }
        public ProductStatus Status { get; set; } = ProductStatus.Active;
        public ProductType Type { get; set; }

    }
}
