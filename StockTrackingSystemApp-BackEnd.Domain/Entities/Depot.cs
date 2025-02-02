namespace StockTrackingSystemApp_BackEnd.Domain.Entities;

public class Depot
{
    public int Id { get; set; }
        
    public string Name { get; set; } = string.Empty;
        
    public string Location { get; set; } = string.Empty;
        
    // Depoya ait kullanıcı bilgisi
    public int UserId { get; set; }
    public User User { get; set; } = null!; // EF Core atayacak
        
    // Depodaki ürünler
    public ICollection<Product> Products { get; set; } = new List<Product>();
}