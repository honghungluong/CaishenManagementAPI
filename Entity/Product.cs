namespace CaishenManagementAPI.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal? InPrice { get; set; }
        public decimal Price { get; set; }

        public int StockQuantity { get; set; }
    }
}
