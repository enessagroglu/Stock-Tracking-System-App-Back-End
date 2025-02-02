namespace StockTrackingSystemApp_BackEnd.Application.DTOs;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public int DepotId { get; set; }
}