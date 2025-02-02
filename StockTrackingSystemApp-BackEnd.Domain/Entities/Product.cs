namespace StockTrackingSystemApp_BackEnd.Domain.Entities;

public class Product
{
    public int Id { get; set; }
        
    public string Name { get; set; } = string.Empty;
        
    public decimal Price { get; set; }
        
    public string Description { get; set; } = string.Empty;
        
    // Kategori ilişkisi
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!; // EF Core atayacak
        
    // Depo ilişkisi
    public int DepotId { get; set; }
    public Depot Depot { get; set; } = null!;
}