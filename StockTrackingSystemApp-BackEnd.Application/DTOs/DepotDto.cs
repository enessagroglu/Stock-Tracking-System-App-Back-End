namespace StockTrackingSystemApp_BackEnd.Application.DTOs;

public class DepotDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public int UserId { get; set; }
}