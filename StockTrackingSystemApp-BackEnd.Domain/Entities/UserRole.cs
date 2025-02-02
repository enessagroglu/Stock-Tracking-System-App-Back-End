namespace StockTrackingSystemApp_BackEnd.Domain.Entities;

public class UserRole
{
    public int Id { get; set; }
        
    public string RoleName { get; set; } = string.Empty;
        
    // Örnek statik tanımlamalar
    public static UserRole Admin { get; } = new UserRole { Id = 1, RoleName = "Admin" };
    public static UserRole User { get; } = new UserRole { Id = 2, RoleName = "User" };
}